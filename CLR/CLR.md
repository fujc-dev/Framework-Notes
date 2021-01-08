
## .NET FRAMEWORK 公共语言运行时
### Common Language Runtime
```text
    公共语言运行时是一个由多种编程语言使用的“运行时”，怎么理解这个概念呢?
        -- 我们的编程语言写的代码，由编译器生成为IL代码，由CLR去运行，CLR会通过JIT将IL代码再次编译成机器码（二进制文件），
    完成程序的运行，当然编译器编译代码的时候，也是需要按照CLR标准来编译的。
        -- CLR包含公共语言规范（Common Language Specification CLS），不管用什么语言写的代码，编码规则都是依赖
    于CLR，类怎么写，格式是什么，不管是什么语言都要按照这个规范来写，类继承或者实现也一样；
        -- CLR包含通用类型系统（Common Type System CTS），就是说所有的语言使用的类型都是CLR提供的，有固定标准；
        -- 所有的标准都是CLR提供的，并且是不可逾越的，一切都依赖于CLR。
```


#### 托管模块
```text
    在Visual Studio中我们编写C#的一个Class类之后，由编译器检查语法和分析源代码，然后产生一个PE文件，我们称之为托管模块。
```
![将源代码编译成托管模块](https://github.com/fujc-dev/Framework-Notes/blob/master/CLR/imgs/将源代码编译成托管模块.png)
#### PE

```text
	PE是Portable Executable（可移植执行体）简称。
    托管模块是标准的32位Microsoft Windows可移植执行体（PE32）文件，或者标准的64位Windows可移植执行体（PE32+）文件，这些执行提文件都需要CLR才能执行；
    
    
```

```text
注释：数据执行保护（Data Execution Prevention，DEP）地址空间布局随机化（Address Space Layout Randomization，ASLR）这两个功能增加整个系统的安全性。
```

#### 托管模块的各个组成部分

```text
PE32或PE32+头

PE文件是托管模块，这个PE文件会由一个头（PE32、PE32+表示文件的格式），标准的Windows PE文件头，如果这个头使用PE32格式，文件只能在Windows32位或者64版本上运行，如果这个头文件使用了PE32+格式，那么对不起，这个文件只能在Windows64位版本上运行。
```
```text
CLR头+

包含使这个模块成为托管模块的信息。头中包含要求的CLR版本，一些标志，托管模块入口方法的MethodDef元数据token，模块的元数据、资源、强名称以及其他不太重要的数据项的位置/大小；
这里涉及到一个专有名字RVA：偏移地址；
```
```text
元数据

每个托管模块都包含元数据表：
1、描述源代码中定义的类型和成员；
2、源代码引言的成员和类型；
总结：我们反射的时候，就是通过对元数据的解析，完成对成员和方法的访问。
```
```text
IL（中间语言）代码

编译器编译源代码时产生的代码。这些代码在运行时，CLR将IL编程本地CPU指令，也就是我们说的机器码，JIT了解一下。
```




##### PE32

#### CLR核心功能
```text
    内存管理
    程序集
    安全性
    异常处理
    线程管理等
```