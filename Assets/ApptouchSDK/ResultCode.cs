using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResultCode {
    // general result code 0 - 9
    public const int SUCCESS            = 0;
    public const int NOT_CONNECTED      = 1;
    public const int FAILED             = 2;
    public const int FAILED_FORCE_CLOSE = 3;

    // payment result code 10 - 19
    public const int PAY_SUCCESS        = 10;
    public const int PAY_FAILURE        = 11;
    public const int PAY_CANCEL         = 12;
    public const int PAY_UNKNOWN_ERROR  = 13;
}
