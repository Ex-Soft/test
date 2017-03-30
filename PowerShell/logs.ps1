param(
# Database alias: 
# d=default
# q=QA
# u=UAT
# s=STG
# p=PROD
# o=Other
[string]$db = '',
# Max number of returned lines
[int]$n = 100,
# Where expresion for query
[string]$w = 'InsertDate < getutcdate()',
# Result file
[string]$r = '.\orelogs.{dbtype}.' + (Get-Date -format "yyyy_MM_dd_HH_mm") + '.log',
# ServerInstance for Other db
[string]$db_si = '',
# Database name for Other db
[string]$db_n = '',
# Username for Other db
[string]$db_un = '',
# Password for Other db
[string]$db_pwd = ''
)

$params = @{
'Database' = "OreLogs"
'Query' = "
SELECT q.* 
FROM 
    (SELECT TOP $n insertdate, callsite, _level, _message, stacktrace 
     FROM SunOppsLog 
     WHERE $w 
     Order By InsertDate Desc) q 
ORDER BY q.InsertDate"
}

switch ($db) {
    #default
    "d" { 
        $params['ServerInstance'] = 'sunopps-se-default.database.windows.net'
        $params['Username'] = 'oredba'
        $params['Password'] = 'P@ssw0rd'
        $r = $r -replace "{dbtype}", "DEFAULT"
    }
    #qa
    "q" {
        $params['ServerInstance'] = 'sunopps2-qa.database.windows.net'
        $params['Username'] = 'SunOppsServicesUser'
        $params['Password'] = 'SOQA789&*('
        $r = $r -replace "{dbtype}", "QA"
    }
    #uat
    "u" {
        $params['ServerInstance'] = 'sunopps2-uat.database.windows.net'
        $params['Username'] = 'SunOppsUser'
        $params['Password'] = 'SOUAT789&*('
        $r = $r -replace "{dbtype}", "UAT"
    }
    #stg
    "s" {
        $params['ServerInstance'] = 'sunopps2-stg.database.windows.net'
        $params['Username'] = 'SunOppsUser'
        $params['Password'] = 'SOSTG789&*('
        $r = $r -replace "{dbtype}", "STG"
    }
    #prod
    "p" {
        $params['ServerInstance'] = 'sunopps2.database.windows.net'
        $params['Username'] = 'oreread'
        $params['Password'] = 'OREPRD123!@#'
        $r = $r -replace "{dbtype}", "PROD"
    }
    "o" {
        $params['ServerInstance'] = $db_si
        $params['Username'] = $db_un
        $params['Password'] = $db_pwd
        $params['Database'] = $db_n
        $r = $r -replace "{dbtype}", "OTHER"

    }
    #dev
    default {
        $params['ServerInstance'] = 'air\inst5'
        $params['Username'] = 'sa'
        $params['Password'] = 'password'
        $params['Database'] = 'ORELogs_Default'
        $r = $r -replace "{dbtype}", "DEV"
    }
}

$res = Invoke-Sqlcmd @params
Set-Location $PSScriptRoot
"Instance: $($params.ServerInstance)
Query: $($params.Query)" | Out-File $r
$res | Out-File $r -Append
