# This dockerfile is just for creating a Unix container
# that can be used for building and running dotnet code.
# It is not related to Jenkins, use it to play around
# and test the code (see README file).
FROM ubuntu

# if we want to install via apt
USER root
RUN apt-get update
RUN apt-get install -y sudo

RUN sudo apt-get install -y wget
RUN wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN sudo dpkg -i packages-microsoft-prod.deb
RUN sudo apt-get install -y apt-transport-https && \
  sudo apt-get update
RUN sudo apt-get install -y dotnet-sdk-5.0
RUN sudo dotnet tool install --global coverlet.console
RUN echo "export PATH=\${PATH}:/root/.dotnet/tools" >> ~/.bashrc
RUN sudo apt-get install -y vim

#RUN adduser \
#  --disabled-password \
#  --home /app \
#  --gecos '' AAA \
#  && chown -R AAA /app
#USER AAA

# drop back to the regular jenkins user - good practice
#USER jenkins

EXPOSE 5000
