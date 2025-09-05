pipeline {
  agent any

  stages {
    stage('Checkout') {
      steps {
        checkout scm
      }
    }

    stage('Dotnet Version') {
      steps {
        sh 'dotnet --version'
      }
    }

    stage('Restore') {
      steps {
        sh 'dotnet restore'
      }
    }

    stage('Build') {
      steps {
        sh 'dotnet build --no-restore --configuration Debug'
      }
    }

    stage('Test') {
      steps {
        sh 'mkdir -p TestResults'
        sh 'dotnet test --no-build --logger "junit;LogFilePath=TestResults/results.xml"'
      }
      post {
        always {
          junit 'TestResults/results.xml'
        }
      }
    }
  }
}
