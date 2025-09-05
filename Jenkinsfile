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
                // Make sure the folder exists inside project folder
                sh 'mkdir -p ./ApiQuicktest/TestResults'

                // Run tests with JUnit logger inside project folder
                sh 'dotnet test ./ApiQuicktest/ApiQuicktest.csproj --no-build --logger "junit;LogFilePath=./ApiQuicktest/TestResults/results.xml"'

                // Debug: list contents
                sh 'ls -l ./ApiQuicktest/TestResults'
            }
            post {
                always {
                    // Archive test results from project folder
                    junit './ApiQuicktest/TestResults/results.xml'
                }
            }
        }
    }
}
