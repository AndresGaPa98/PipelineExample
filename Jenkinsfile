pipeline{
    agent any
    stages{
      stage('Restore PACKAGES') {
          steps {
                    echo 'Restoring packages'
                    bat "dotnet restore"
                    echo 'Packages restored'
          }
        }
        stage('Build'){
            steps{
                    echo 'Building...'
                    bat "dotnet build"
                    echo '-------------------------------------------------------------------------------------'
            
            }
        }
        stage('Run'){
            steps{
                    echo 'Running...'
                    bat "dotnet run"
                    echo '-------------------------------------------------------------------------------------'
            
            }
        }
    }
}
