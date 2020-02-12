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
    }
}
