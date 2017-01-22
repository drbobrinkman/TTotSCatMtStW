Shader "Custom/WaveShader" {
	Properties{
		_Color("Color", Color) = (1,1,0,1)
		_Sizing("Sizing", Float) = 1.0
		_Spacing("Spacing", Float) = 0.5
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

			float _Sizing, _Spacing;
			fixed4 _Color;

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
