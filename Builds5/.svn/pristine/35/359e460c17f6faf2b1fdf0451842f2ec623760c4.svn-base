// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32122,y:32671|emission-46-OUT,alpha-155-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:32742,y:32815,ptlb:node_2,ptin:_node_2,tex:f99becf018bd18e4e8252bb6108eadb6,ntxv:2,isnm:False|UVIN-7-UVOUT;n:type:ShaderForge.SFN_Panner,id:7,x:32912,y:32815,spu:0,spv:1|DIST-17-TSL;n:type:ShaderForge.SFN_Time,id:17,x:33066,y:32825;n:type:ShaderForge.SFN_Tex2d,id:41,x:32828,y:32601,ptlb:node_2_copy,ptin:_node_2_copy,tex:46fc31b92fe8ca8459c2af380aae5f83,ntxv:2,isnm:False|UVIN-43-UVOUT,MIP-98-X;n:type:ShaderForge.SFN_Panner,id:43,x:33017,y:32601,spu:0,spv:-1|UVIN-87-UVOUT,DIST-45-TSL;n:type:ShaderForge.SFN_Time,id:45,x:33243,y:32650;n:type:ShaderForge.SFN_Add,id:46,x:32452,y:32600|A-41-G,B-2-G;n:type:ShaderForge.SFN_TexCoord,id:87,x:33243,y:32457,uv:1;n:type:ShaderForge.SFN_FragmentPosition,id:98,x:33245,y:32936;n:type:ShaderForge.SFN_Add,id:155,x:32447,y:32765|A-41-G,B-2-G;n:type:ShaderForge.SFN_Add,id:160,x:32413,y:32451|B-46-OUT;proporder:2-41;pass:END;sub:END;*/

Shader "Alex'sElementalShader" {
    Properties {
        _node_2 ("node_2", 2D) = "black" {}
        _node_2_copy ("node_2_copy", 2D) = "black" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform sampler2D _node_2; uniform float4 _node_2_ST;
            uniform sampler2D _node_2_copy; uniform float4 _node_2_copy_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_45 = _Time + _TimeEditor;
                float2 node_43 = (i.uv1.rg+node_45.r*float2(0,-1));
                float4 node_41 = tex2Dlod(_node_2_copy,float4(TRANSFORM_TEX(node_43, _node_2_copy),0.0,i.posWorld.r));
                float4 node_17 = _Time + _TimeEditor;
                float2 node_7 = (i.uv0.rg+node_17.r*float2(0,1));
                float4 node_2 = tex2D(_node_2,TRANSFORM_TEX(node_7, _node_2));
                float node_46 = (node_41.g+node_2.g);
                float3 emissive = float3(node_46,node_46,node_46);
                float3 finalColor = emissive;
/// Final Color:
                return fixed4(finalColor,(node_41.g+node_2.g));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
