# Azeroth.Interop
dotnet framework托管代码和非托管代码（Windows COM，Native C）的互操作

托管代码使用P/Invoke调用C类库中的函数，调用方和被调用方需要遵循的规则如下
* Native C中的规则
  * 使用vc编译器编译为C类库或控制台程序，
  * 必须`导出`那些给C#调用的函数，导出方法1：使用__declspec(dllexport)直接修饰方法；导出方法2：添加一个def文件，添加链接器的参数 /def def文件名
  * 函数调用方式必须为`_stdcall` 或者`_cdecl`,其他方式不可以，windows api的函数调用方式都是_stdcall，visual studio给vc编译器的默认编译参数是`_cdecl`，可以在项目属性编译器中进行更改默认参数
* c#项目中的规则
  * 定义与导出函数一致的static方法，（方法名称和函数名称一致，方法签名和函数签名一致），
  * 在c#中定义和C中结构一致的struct，保证参数类型，返回值类型一致，
  * 在C#中定义和C中函数签名一致的委托类型，P/Invoke不能使用泛型委托
  * 项目属性->调试，勾选 启用本机代码调试，就可以在vs中逐行调试C类库中的函数
  
  托管代码导出COM组件，把com注册到windows
  
  托管代码导入windows已经注册的COM组件
