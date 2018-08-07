# License4net
主要用于：.net 网站、winform、WPF客户端程序的软件授权，授权文件生成，版权控制和授权管理。
设计思路可参考：https://www.jianshu.com/u/de02af3c1c1b

- 第一步 生成授权文件
![image](https://github.com/lilunjia/License4net/blob/master/Images/codegenerate.jpg)
选择需要的版本类型，输入授权控制的类型：网址限制、CPU限制、硬盘序列号等，然后导出授权文件。如果需要获得 CPU序列号、硬盘序列号，可编译运行实例项目Tool_MachineCode。
这个生成授权文件的组件源码有偿提供 ￥80，请联系我的qq17416531

- 第二步 拷贝授权文件
将授权文件拷贝到网站根目录或客户端程序目录下即可

- 第三部 在需要增加限制的项目中增加授权校验代码 
参考示例项目 
WebApplication_LisenceFileTest
![image](https://github.com/lilunjia/License4net/blob/master/Images/webcode.jpg)
WindowsForms_LisenceFileTest
![image](https://github.com/lilunjia/License4net/blob/master/Images/clientcode.jpg)

