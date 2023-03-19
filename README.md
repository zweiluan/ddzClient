# ddzClient
斗地主客户端

这个demo在Gameframework的基础上集成了Luban、Hybrid、XLua

这个项目的主要目的是  
1、搭建一个基本能够实现商业化的简易框架  
2、熟悉UGUI 

XLua的使用，仅用于为UI提供脚本，并未使用全Lua开发。UI使用的Lua脚本随UI预制体打包，并未使用独立的AB打包。

其中最主要的问题集中在Hybrid对XLua的热更。

其中有两个坑，

1、XLuaDLL的extern扩展方法，这一部分是Hybrid[不支持](https://focus-creative-games.github.io/hybridclr/common_errors/#%E9%81%87%E5%88%B0executionengineexception-not-support-extern-method-xxxx)的。所以需要将它转移到AOT模块中。  

 我的解决办法是放在3rd文件夹中，XLua的核心运行代码仍放在unity-csharp中。
 因此他们已经不在同一个程序集中了，所以需要对具备internal属性的类标记为public，以便访问。
 XLuaDLL依赖的属性也一并转移至AOT中。对于xlua自动生成的代码和将XLua源码修改后不适配的问题，需要修改模板文件。
 
2、XLua生成的代码带有[MonoPInvokeCallback](https://focus-creative-games.github.io/hybridclr/common_errors/#%E4%BD%BF%E7%94%A8addressable%E8%BF%9B%E8%A1%8C%E7%83%AD%E6%9B%B4%E6%96%B0%E6%97%B6-%E5%8A%A0%E8%BD%BD%E8%B5%84%E6%BA%90%E5%87%BA%E7%8E%B0-unityengine-addressableassets-invlidkeyexception-exception-of-type-unityengine-addressableassets-invalidkeyexception-was-thrown-no-asset-found-with-for-key-xxxx-%E5%BC%82%E5%B8%B8)

这有两个解决办法，

1、先使用xlua生成代码，在使用Hybrid的打包流程。这样xlua的使用的MonoPInvokeCallback就能正常链接  
2、使用Hybrid提供的预补充功能。  
个人的建议是都用吧。

3、XLua是有全lua配置后，自动生成的代码中参数名异常。

我的解决办法是不使用默认配置。自己对Lua使用到的功能动态打标签。  
  
  
  所以正常的打包流程是  
  1、先生成使用xlua生成代码  
  2、使用hybrid生成link  
  3、打包一次  
  4、使用hybrid一次性生成  
  5、正常打包，之后就可以正常热更了。
  
