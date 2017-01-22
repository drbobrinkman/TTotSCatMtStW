Shader "Custom/WaveShader" {
	Properties{
		_Color("Color", Color) = (1,1,0,1)
		_Sizing("Sizing", Float) = 1.0
		_Spacing("Spacing", Float) = 0.5
		_LastCryTime("Last Cry Time", Float) = 0.0
		_CurTime("Current Time", Float) = 0.0
		_CryLocation("Cry Location", Vector) = (0, 0, 0, 0)
	}

		SubShader{
			Lighting Off
			Tags{
			"Queue" = "Transparent"
			"IgnoreProjector" = "False"
			"RenderType" = "Transparent"
		}

			Cull Back
			ZWrite On

			CGPROGRAM
	#pragma surface surf Unlit alpha
	#pragma exclude_renderers flash
#pragma target 3.0

			float _Sizing, _Spacing, _LastCryTime, _CurTime;
			fixed4 _Color;
			float4 _CryLocation;

	struct Input {
		float3 worldPos;
	};

	half4 LightingUnlit(SurfaceOutput s, half3 lightDir, half atten)
	{
		return half4(s.Albedo, s.Alpha);
	}

	void surf(Input IN, inout SurfaceOutput o) {
		float3 curPos = IN.worldPos.xyz / _Spacing;
		float3 closestDot = round(curPos);
		curPos *= _Spacing;
		closestDot *= _Spacing;

		closestDot.y = curPos.y;

		float dist = distance(closestDot, curPos);

		//Next, account for effect of cries. For now, shear direction is always +z to the right side of fault, -z to the left side
		float3 shearDirection = float3(0.0f, 0.0f, 1.0f);
		float3 dirFromBaby = closestDot - _CryLocation;
		dirFromBaby.y = 0.0f;
		dirFromBaby = normalize(dirFromBaby);
		float3 whichWay = dirFromBaby - shearDirection;
		whichWay.y = 0.0f;
		whichWay = normalize(whichWay);
		float theta = atan2(whichWay.z, whichWay.x);
		
		//float theta = acos(cosTheta);
		float scaleDueToAngle = pow(8, pow(sin(4*theta), 5));

		float distancePerSecond = 3.0f; //in meters per second
		float wavePeakDistance = (_CurTime - _LastCryTime)*distancePerSecond;
		float peakWidth = 2.0f;
		float distFromSource = distance(closestDot, _CryLocation);
		float distanceFromPeak = min(abs(distFromSource - wavePeakDistance), peakWidth);

		dist = dist * lerp(1.0, scaleDueToAngle, 1 - distanceFromPeak/ peakWidth);

		float scaleFactor = 1.0f - pow(1.0f - min(1.0f, max(0, (_Sizing - dist)/_Sizing)),5);

		



		o.Albedo = _Color;
		o.Alpha = scaleFactor;
		if (IN.worldPos.x > 5.0f || IN.worldPos.x < -5.0f ||
			IN.worldPos.z > 5.0f || IN.worldPos.z < -5.0f) {
			o.Alpha = 0.0f;
		}
	}
	ENDCG
	}
		Fallback "Diffuse"
}
