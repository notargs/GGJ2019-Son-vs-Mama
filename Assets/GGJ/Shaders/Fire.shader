Shader "Unlit/Fire"
{
    Properties
    {
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }

        ZWrite Off
        LOD 100
        Blend One One

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Noise/SimplexNoise3D.hlsl"
            
            

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float a = snoise(float3(i.uv * 20.0f, 0) + float3(0, -5, 1) * _Time.y) + (2- uv.y * 4);
                float4 col = float4(0, 0, 0, 1);
                col = lerp(col, float4(1, 0, 0, 1), smoothstep(0.0, 0.7, a));
                col = lerp(col, float4(1, 0.5, 0, 1), smoothstep(0.7, 1.0, a));
                //col = lerp(col, float4(1, 1, 0.5, 0), smoothstep(0.9, 1.0, a));
                col.rgb *= 1 - uv.y;
                return col;
            }
            ENDCG
        }
    }
}
