// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:True,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32258,y:32732|diff-18-OUT;n:type:ShaderForge.SFN_Lerp,id:2,x:32995,y:32411|A-38-RGB,B-55-RGB,T-5-OUT;n:type:ShaderForge.SFN_RemapRange,id:5,x:33459,y:32390,frmn:-1,frmx:1,tomn:0,tomx:1|IN-6-OUT;n:type:ShaderForge.SFN_Sin,id:6,x:33630,y:32485|IN-7-OUT;n:type:ShaderForge.SFN_Multiply,id:7,x:33787,y:32485|A-8-OUT,B-9-T;n:type:ShaderForge.SFN_ValueProperty,id:8,x:33977,y:32445,ptlb:Speed,ptin:_Speed,glob:False,v1:35;n:type:ShaderForge.SFN_Time,id:9,x:33977,y:32536;n:type:ShaderForge.SFN_Lerp,id:10,x:32822,y:32524|A-2-OUT,B-49-RGB,T-226-OUT;n:type:ShaderForge.SFN_Lerp,id:14,x:32659,y:32662|A-10-OUT,B-21-RGB,T-234-OUT;n:type:ShaderForge.SFN_Lerp,id:18,x:32502,y:32784|A-14-OUT,B-32-RGB,T-242-OUT;n:type:ShaderForge.SFN_Tex2d,id:21,x:32863,y:32746,ptlb:node_21,ptin:_node_21,tex:83719a48ef8821343bc24c7bf9d6d863,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:32,x:32711,y:32814,ptlb:node_32,ptin:_node_32,tex:e6b23d716690ec84a8813492bbbc5b1b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:38,x:33224,y:32234,ptlb:node_38,ptin:_node_38,tex:f453562bc8cb83f47946f456e1e08618,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:49,x:33107,y:32600,ptlb:node_49,ptin:_node_49,tex:7a08a2c5059b07f4ab9206f602f04c94,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:55,x:33224,y:32461,ptlb:node_55,ptin:_node_55,tex:c8d4bf19fd2bc844f977bb6d4792fa0b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_RemapRange,id:226,x:33285,y:32665,frmn:-1,frmx:1,tomn:0,tomx:1|IN-228-OUT;n:type:ShaderForge.SFN_Sin,id:228,x:33423,y:32751|IN-230-OUT;n:type:ShaderForge.SFN_Multiply,id:230,x:33580,y:32751|A-253-OUT,B-232-T;n:type:ShaderForge.SFN_Time,id:232,x:33770,y:32802;n:type:ShaderForge.SFN_RemapRange,id:234,x:33169,y:32882,frmn:-1,frmx:1,tomn:0,tomx:1|IN-236-OUT;n:type:ShaderForge.SFN_Sin,id:236,x:33307,y:32968|IN-238-OUT;n:type:ShaderForge.SFN_Multiply,id:238,x:33464,y:32968|A-255-OUT,B-240-T;n:type:ShaderForge.SFN_Time,id:240,x:33654,y:33019;n:type:ShaderForge.SFN_RemapRange,id:242,x:33028,y:33071,frmn:-1,frmx:1,tomn:0,tomx:1|IN-244-OUT;n:type:ShaderForge.SFN_Sin,id:244,x:33166,y:33157|IN-246-OUT;n:type:ShaderForge.SFN_Multiply,id:246,x:33323,y:33157|A-257-OUT,B-248-T;n:type:ShaderForge.SFN_Time,id:248,x:33513,y:33208;n:type:ShaderForge.SFN_ValueProperty,id:253,x:33787,y:32725,ptlb:Speed_copy,ptin:_Speed_copy,glob:False,v1:30;n:type:ShaderForge.SFN_ValueProperty,id:255,x:33654,y:32968,ptlb:Speed_copy_copy,ptin:_Speed_copy_copy,glob:False,v1:25;n:type:ShaderForge.SFN_ValueProperty,id:257,x:33513,y:33157,ptlb:Speed_copy_copy_copy,ptin:_Speed_copy_copy_copy,glob:False,v1:20;proporder:8-21-32-38-49-55-257-255-253;pass:END;sub:END;*/

Shader "Shader Forge/mask" {
    Properties {
        _Speed ("Speed", Float ) = 35
        _node_21 ("node_21", 2D) = "white" {}
        _node_32 ("node_32", 2D) = "white" {}
        _node_38 ("node_38", 2D) = "white" {}
        _node_49 ("node_49", 2D) = "white" {}
        _node_55 ("node_55", 2D) = "white" {}
        _Speed_copy_copy_copy ("Speed_copy_copy_copy", Float ) = 20
        _Speed_copy_copy ("Speed_copy_copy", Float ) = 25
        _Speed_copy ("Speed_copy", Float ) = 30
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _Speed;
            uniform sampler2D _node_21; uniform float4 _node_21_ST;
            uniform sampler2D _node_32; uniform float4 _node_32_ST;
            uniform sampler2D _node_38; uniform float4 _node_38_ST;
            uniform sampler2D _node_49; uniform float4 _node_49_ST;
            uniform sampler2D _node_55; uniform float4 _node_55_ST;
            uniform float _Speed_copy;
            uniform float _Speed_copy_copy;
            uniform float _Speed_copy_copy_copy;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i)*2;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb*2;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float2 node_281 = i.uv0;
                float4 node_9 = _Time + _TimeEditor;
                float4 node_232 = _Time + _TimeEditor;
                float4 node_240 = _Time + _TimeEditor;
                float4 node_248 = _Time + _TimeEditor;
                finalColor += diffuseLight * lerp(lerp(lerp(lerp(tex2D(_node_38,TRANSFORM_TEX(node_281.rg, _node_38)).rgb,tex2D(_node_55,TRANSFORM_TEX(node_281.rg, _node_55)).rgb,(sin((_Speed*node_9.g))*0.5+0.5)),tex2D(_node_49,TRANSFORM_TEX(node_281.rg, _node_49)).rgb,(sin((_Speed_copy*node_232.g))*0.5+0.5)),tex2D(_node_21,TRANSFORM_TEX(node_281.rg, _node_21)).rgb,(sin((_Speed_copy_copy*node_240.g))*0.5+0.5)),tex2D(_node_32,TRANSFORM_TEX(node_281.rg, _node_32)).rgb,(sin((_Speed_copy_copy_copy*node_248.g))*0.5+0.5));
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _Speed;
            uniform sampler2D _node_21; uniform float4 _node_21_ST;
            uniform sampler2D _node_32; uniform float4 _node_32_ST;
            uniform sampler2D _node_38; uniform float4 _node_38_ST;
            uniform sampler2D _node_49; uniform float4 _node_49_ST;
            uniform sampler2D _node_55; uniform float4 _node_55_ST;
            uniform float _Speed_copy;
            uniform float _Speed_copy_copy;
            uniform float _Speed_copy_copy_copy;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i)*2;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float2 node_282 = i.uv0;
                float4 node_9 = _Time + _TimeEditor;
                float4 node_232 = _Time + _TimeEditor;
                float4 node_240 = _Time + _TimeEditor;
                float4 node_248 = _Time + _TimeEditor;
                finalColor += diffuseLight * lerp(lerp(lerp(lerp(tex2D(_node_38,TRANSFORM_TEX(node_282.rg, _node_38)).rgb,tex2D(_node_55,TRANSFORM_TEX(node_282.rg, _node_55)).rgb,(sin((_Speed*node_9.g))*0.5+0.5)),tex2D(_node_49,TRANSFORM_TEX(node_282.rg, _node_49)).rgb,(sin((_Speed_copy*node_232.g))*0.5+0.5)),tex2D(_node_21,TRANSFORM_TEX(node_282.rg, _node_21)).rgb,(sin((_Speed_copy_copy*node_240.g))*0.5+0.5)),tex2D(_node_32,TRANSFORM_TEX(node_282.rg, _node_32)).rgb,(sin((_Speed_copy_copy_copy*node_248.g))*0.5+0.5));
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
