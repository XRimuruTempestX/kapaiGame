// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "X1/texie/2Dmask_hero"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_stencil("stencil", Float) = 2
		_MainTex("MainTex", 2D) = "white" {}
		_Color("Color", Color) = (0,0,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "AlphaTest+0" "IsEmissive" = "true" "RenderPipeline" = "UniversalPipeline" }
		Cull Back
		ZWrite Off
		ZTest Always
		Stencil
		{
			Ref [_stencil]
			Comp Always
			Pass Replace
		}
		
		Pass
		{
			Name "UniversalForward"
			Tags { "LightMode"="UniversalForward" }
			ZWrite Off
			ZTest Always
			Cull Back
			
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

			struct Attributes
			{
				float4 positionOS : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct Varyings
			{
				float4 positionCS : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			CBUFFER_START(UnityPerMaterial)
				float4 _Color;
				float4 _MainTex_ST;
				float _Cutoff;
				float _stencil;
			CBUFFER_END

			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);

			Varyings vert(Attributes input)
			{
				Varyings output;
				output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
				output.uv = input.uv * _MainTex_ST.xy + _MainTex_ST.zw;
				return output;
			}

			half4 frag(Varyings input) : SV_Target
			{
				half mask = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv).r;
				clip(mask - _Cutoff);
				return _Color;
			}
			ENDHLSL
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18707
245;104;1262;457;1228.643;222.7274;1.640542;True;True
Node;AmplifyShaderEditor.SamplerNode;2;-390.1998,61.97916;Inherit;True;Property;_MainTex;MainTex;2;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;16;-327.3582,-118.7897;Inherit;False;Property;_Color;Color;3;0;Create;True;0;0;False;0;False;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;15;-260.1414,346.6994;Inherit;False;Property;_stencil;stencil;1;0;Create;True;0;0;True;0;False;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;1;126,-35;Float;False;True;-1;2;ASEMaterialInspector;0;0;CustomLighting;X1/texie/2Dmask_hero;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;2;False;-1;7;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Opaque;;AlphaTest;All;14;all;True;True;True;True;0;False;-1;True;2;True;15;255;False;-1;255;False;-1;7;False;-1;3;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;1;2;16;0
WireConnection;1;10;2;1
ASEEND*/
//CHKSM=32405E7D2D18E1209C495BA107DBEEC14B4227B2