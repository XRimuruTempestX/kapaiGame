using Fantasy.Entitas;

namespace Fantasy.Authentication;

public class EncryptHelperComponent : Entitas.Entity
{
    public string privateKey = "<RSAKeyValue><Modulus>r+WZpxAclVkw2SkNj3Uu/U0ZRHVRyu5z/DE4nqcRh/9ijWsupZURwIJXhkPYm/UnwsS00QOOzLgmfAKo2pcP+aFdwMzWTBIinn2d5Lu9Oj70cG8wxo4upf+dno/EMRAvocVvgw/2AaZezMLyNG+VMmxQzaiiIt0kwS++dgXnjIk=</Modulus><Exponent>AQAB</Exponent><P>xO1lnwaFlDCez9B7126k8/g6myIs1UVm8+KpNwmmp5402nbXeKaEWhNIHe3FH+/O7VJvhfk9sbbMvL6HNuXp/w==</P><Q>5Kk3J3GEbuCX6X1T/NJscU+GFe4LvuocfOdE1KUozqCVKUETOncvxFeEMxwyEDfnoLcu+trQ49Esb/6wJBI5dw==</Q><DP>kxnubiMWB0NmbkADMkMBTwke5iFaMhm8tPOciXNZHR6Nxp89h2+DsDF1Dn49YQTmotqQWhh7YFP3jgoYwQZviw==</DP><DQ>SCD8reuIC/W61cNb9/dkj8W3FTnW6K0uuVO2iaFjovJSuwW1DA9GuRemMv0k6arI3RCLuEPH+uUjsFxVsbsx9w==</DQ><InverseQ>ZqTxGcRZ/k9SyGrl6j+LdbKoPxzUH/XuuJgmO+5p9Ut4+VAkVu23dmnjl4Ys5sTwOauoyxipghhvkJEEDDs1fA==</InverseQ><D>boN7PpPI4azgHBDHDFM76rn+Hhz3/uBCzzi9sjCVuzSh3uhwrmgydxltlFYcSiCFksG0OX5awhURWOjy3iP7THjJDcFSh36gGOomxnuKbsAU13ZFTe68diH2rvjN1jy6LVTw3TG4VT4N+BmZKKIpT6IgZ2hC+krkHmaE6bLMKOE=</D></RSAKeyValue>";
    public string publicKey = "<RSAKeyValue><Modulus>r+WZpxAclVkw2SkNj3Uu/U0ZRHVRyu5z/DE4nqcRh/9ijWsupZURwIJXhkPYm/UnwsS00QOOzLgmfAKo2pcP+aFdwMzWTBIinn2d5Lu9Oj70cG8wxo4upf+dno/EMRAvocVvgw/2AaZezMLyNG+VMmxQzaiiIt0kwS++dgXnjIk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
}