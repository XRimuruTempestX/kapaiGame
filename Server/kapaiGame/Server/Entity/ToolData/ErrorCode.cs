namespace Fantasy.ToolData;

public  class ErrorCode
{

    public const uint Success = 0;
    
    //---------注册
    //注册账号有误
    public const uint RegisterAccountOrPasswordErrorCode = 1001;

    //已经存在该账号
    public const uint ExitAccount = 1002;
    
    //--------登录
    //密码错误
    public const uint LoginPasswordErrorCode = 1003; 
    //账号不存在
    public const uint LoginAccountNotExistErrorCode = 1004;
    
    //账号已经登录
    public const uint LoginAccountAlreadyExistErrorCode = 1005;
    //--------END
    
    //抽卡
    public const uint GachaFailedErrorCode = 1006;
    
    //-----END
}