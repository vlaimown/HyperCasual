Shader "Sprites/tutor/testtt"
{
    Properties
    {
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
        _Color("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha("Enable External Alpha", Float) = 0

        _Cutoff("Alpha Cutoff", Range(0,1)) = 0.5
    }

        SubShader
        {
            Tags
            {
                "Queue" = "Transparent"
                "IgnoreProjector" = "True"
                "RenderType" = "Transparent"
                "PreviewType" = "Plane"
                "CanUseSpriteAtlas" = "True"
            }

            Cull Off
            Lighting Off
            ZWrite Off
            Blend One OneMinusSrcAlpha

            CGPROGRAM
            #pragma surface surf Lambert vertex:vert alphatest:_Cutoff addshadow nofog nolightmap nodynlightmap keepalpha noinstancing
            #pragma multi_compile_local _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #include "UnitySprites.cginc"

            struct Input
            {
                float2 uv_MainTex;
                fixed4 color;
            };

            void vert(inout appdata_full v, out Input o)
            {
                v.vertex = UnityFlipSprite(v.vertex, _Flip);

                #if defined(PIXELSNAP_ON)
                v.vertex = UnityPixelSnap(v.vertex);
                #endif

                UNITY_INITIALIZE_OUTPUT(Input, o);
                o.color = v.color * _Color * _RendererColor;
            }

            void surf(Input IN, inout SurfaceOutput o)
            {
                fixed4 c = SampleSpriteTexture(IN.uv_MainTex) * IN.color;
                o.Albedo = c.rgb * c.a;
                o.Alpha = c.a;
            }
            ENDCG

                // ShadowCaster Pass
                Pass
                {
                    Name "ShadowCaster"
                    Tags { "LightMode" = "ShadowCaster" }

                    ZWrite On
                    ZTest LEqual
                    ColorMask 0

                    CGPROGRAM
                    #pragma vertex vert
                    #pragma fragment frag
                    #pragma multi_compile_shadowcaster
                    #include "UnityCG.cginc"

                    struct v2f
                    {
                        V2F_SHADOW_CASTER;
                    };

                    v2f vert(appdata_base v)
                    {
                        v2f o;
                        TRANSFER_SHADOW_CASTER(o) // Убрано NORMALOFFSET
                            return o;
                    }

                    float4 frag(v2f i) : SV_Target
                    {
                        SHADOW_CASTER_FRAGMENT(i)
                    }
                    ENDCG
                }
        }

            Fallback "Transparent/VertexLit"
}