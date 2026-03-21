// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "X1_UI_ColorChange"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_stencil("stencil", Float) = 0

	}
	
	SubShader
	{
		
		
		Tags { "RenderType"="Transparent" "Queue"="Transparent+1" }
	LOD 100

		CGINCLUDE
		#pragma target 3.0
		ENDCG
		Blend SrcAlpha OneMinusSrcAlpha
		AlphaToMask Off
		Cull Off
		ColorMask RGBA
		ZWrite Off
		ZTest Always
		Offset 0 , 0
		Stencil
		{
			Ref [_stencil]
			CompFront Equal
			PassFront Keep
			FailFront Keep
			ZFailFront Keep
			CompBack Always
			PassBack Keep
			FailBack Keep
			ZFailBack Keep
		}
		
		// GrabPass{ }

		Pass
		{
			Name "UniversalForward"
			Tags { "LightMode"="UniversalForward" }
			
			ZWrite Off
			ZTest LEqual
			Blend DstColor Zero // 乘法混合：将当前颜色与背景颜色相乘
			// 或者是 Blend SrcAlpha OneMinusSrcAlpha 进行普通的Alpha混合
			
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_instancing
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			
			struct appdata
			{
				float4 vertex : POSITION;
				float4 color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			
			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
				float _stencil;
				float4 _Color;
			CBUFFER_END
			
			v2f vert ( appdata v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				UNITY_TRANSFER_INSTANCE_ID(v, o);

				o.vertex = TransformObjectToHClip(v.vertex.xyz);
				o.color = v.color;
				
				return o;
			}
			
			half4 frag (v2f i ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(i);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
				
				// 直接返回设定的颜色和顶点色，通过Blend指令与后面的颜色混合
				return _Color * i.color;
			}
			ENDHLSL
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	
}
/*ASEBEGIN
Version=18707
81;39;1098;270;-311.9507;1296.295;2.885638;True;True
Node;AmplifyShaderEditor.GrabScreenPosition;146;1675.621,-785.9066;Inherit;False;0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ScreenColorNode;147;1989.89,-773.1589;Inherit;False;Global;_GrabScreen0;Grab Screen 0;0;0;Create;True;0;0;False;0;False;Object;-1;False;False;1;0;FLOAT2;0,0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;148;1993.524,-536.6599;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;149;1970.124,-991.6601;Inherit;False;Property;_Color;Color;0;0;Create;True;0;0;False;0;False;1,1,1,1;1,0.6123255,0.1650943,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;150;2306.824,-808.3595;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;151;2282.841,-283.4358;Inherit;False;Property;_stencil;stencil;1;0;Create;True;0;0;True;0;False;0;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1;2453.93,-726.8081;Float;False;True;-1;2;ASEMaterialInspector;100;1;X1_UI_ColorChange;0770190933193b94aaa3065e307002fa;True;Unlit;0;0;Unlit;2;True;2;5;False;-1;10;False;-1;0;1;False;-1;0;False;-1;True;0;False;-1;0;False;-1;False;False;False;False;False;False;True;0;False;-1;True;2;False;-1;True;True;True;True;True;0;False;-1;False;False;False;True;True;255;True;151;255;False;-1;255;False;-1;5;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;True;2;False;-1;True;7;False;-1;True;True;0;False;-1;0;False;-1;True;2;RenderType=Opaque=RenderType;Queue=Transparent=Queue=0;True;2;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=ForwardBase;False;0;;0;0;Standard;1;Vertex Position,InvertActionOnDeselection;1;0;1;True;False;;False;0
WireConnection;147;0;146;0
WireConnection;150;0;149;0
WireConnection;150;1;147;0
WireConnection;150;2;148;0
WireConnection;1;0;150;0
ASEEND*/
//CHKSM=62F64B9313BD04BF911E3DFAF492F789CBFAD327