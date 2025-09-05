pipeline {
    agent any
    environment {
        PATH = "/usr/local/share/dotnet:${env.PATH}"
    }
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
                sh 'dotnet restore ./ApiQuicktest/ApiQuicktest.csproj'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build ./ApiQuicktest/ApiQuicktest.csproj --no-restore --configuration Debug'
            }
        }

        stage('Test') {
    steps {
        sh 'mkdir -p ./ApiQuicktest/TestResults'
        sh 'dotnet test ./ApiQuicktest/ApiQuicktest.csproj --no-build --logger "junit;LogFilePath=./ApiQuicktest/TestResults/results.xml"'
        sh 'ls -l ./ApiQuicktest/TestResults'
    }
    post {
        always {
            junit "ApiQuicktest/TestResults/results.xml"
        }
    }
}

    }
}
