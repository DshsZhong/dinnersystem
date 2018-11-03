<?php
    # this file requires a bom header to let ios plugin run
    
    error_reporting(0);
    mysqli_report(MYSQLI_REPORT_STRICT);

    require_once(__DIR__ . "/backend_proc/backend_main.php");
    
    date_default_timezone_set('Asia/Taipei');
    $backend_main = new backend_proc\backend_main();
    $result = $backend_main->run();

    if(is_string($result))
    {
        # header("Content-Type:text/html;");
        echo $result;
    } 
    else
    {
        # header("Content-Type:application/json;");
        echo \json\json_output::output($result);
    } 
?>