Shader "Custom/TMPDistortion"
{
    Properties
    {
        _MainTex ("Font Atlas", 2D) = "white" {}
        _WaveSpeed ("Wave Speed", Float) = 2.0
        _WaveAmplitude ("Wave Amplitude", Float) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _WaveSpeed;
            float _WaveAmplitude;

            v2f vert (appdata_t v)
            {
                v2f o;
                float wave = sin(_Time.y * _WaveSpeed + v.uv.y * 10) * _WaveAmplitude;
                v.vertex.x += wave;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}
