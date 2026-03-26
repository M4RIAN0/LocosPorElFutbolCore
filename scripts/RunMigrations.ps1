# Ruta del archivo de configuración (config.json)
$ConfigFilePath = Join-Path $PSScriptRoot 'config.json'

# Verificar si el archivo de configuración existe
if (-Not (Test-Path $ConfigFilePath)) {
    Write-Error "The configuration file is not located in the path: $ConfigFilePath"
    exit 1
}

# Cargar configuraciones desde el archivo JSON
$Config = Get-Content -Raw -Path $ConfigFilePath | ConvertFrom-Json

# Verificar si las configuraciones necesarias están presentes
if (-Not $Config.ProjectPath) {
    Write-Error "The project path is not defined in the configuration file."
    exit 1
}

if (-Not $Config.ConnectionStrings.DefaultConnection) {
    Write-Error "The connection string is not defined in the configuration file."
    exit 1
}

# Obtener la cadena de conexión y la ruta del proyecto desde el archivo de configuración
$ConnectionString = $Config.ConnectionStrings.DefaultConnection
$ProjectPath = $Config.ProjectPath

Write-Host "Sring conexión: $ConnectionString"
Write-Host "Project path: $ProjectPath"

# Función para ejecutar comandos en el directorio adecuado
function Run-Command {
    param (
        [string]$Command
    )
    Write-Host "Executing: $Command"
    try {
        Invoke-Expression $Command
    } catch {
        Write-Error "Error executing the command: $Command"
        exit 1
    }
}

# Función para realizar la limpieza de la base de datos
function Clean-Database {
    $CleanCommand = "dotnet ef database drop --force --no-build --project $ProjectPath"
    Run-Command $CleanCommand
}

# Función para eliminar la última migración
function Remove-LastMigration {
    $RemoveCommand = "dotnet ef migrations remove --project $ProjectPath"
    Run-Command $RemoveCommand
}

# Función para agregar una nueva migración
function Add-Migration {
    param (
        [string]$MigrationName = "Initial"
    )
    $AddCommand = "dotnet ef migrations add $MigrationName --project $ProjectPath"
    Run-Command $AddCommand
}

# Función para actualizar la base de datos con las migraciones
function Update-Database {
    $UpdateCommand = "dotnet ef database update --project $ProjectPath"
    Run-Command $UpdateCommand
}

# Función principal que ejecuta todo el flujo de migraciones
function Run-Migrations {
    Write-Host "Startig process of migrations..."

    Clean-Database
    Remove-LastMigration
    Add-Migration
    Update-Database

    Write-Host "Migrations completed succesfully."
}

# Ejecutar las migraciones
Run-Migrations
