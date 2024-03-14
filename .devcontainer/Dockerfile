# Start from a base image
FROM ubuntu:20.04 as base
ARG node_version=20

# Install zsh, python, perl, nodejs, and .NET Core
RUN apt-get update && apt-get install -y \
    curl gnupg2 lsb-release \
    zsh python3 perl

## Setup NodeJS via Volta
ENV PATH="/root/.volta/bin:$PATH"
RUN curl https://get.volta.sh |bash

RUN volta install "node@$node_version" && \
    volta install pnpm && \
    pnpm setup && \
    pnpm add -g tailwindcss@latest postcss@latest 

## Setup git flow
RUN apt-get update && \
    apt-get install -y git git-flow-avh

# Install .NET Core SDK
RUN wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN apt-get update && \
    apt-get install -y \
        apt-transport-https \
        dotnet-sdk-8.0
        
# Cleanup package manager
RUN apt-get clean && \
    rm -rf /var/lib/apt/lists/

# Set zsh as the default shell
RUN chsh -s $(which zsh)

FROM base as dev

ENV PROJECT_LOCATION=/workspace/SmartOrder
WORKDIR $PROJECT_LOCATION

COPY ./.devcontainer/bootstrap.sh /tmp/bootstrap.sh
RUN chmod +x /tmp/bootstrap.sh && /tmp/bootstrap.sh

VOLUME [\
    "/workspaces/SmartOrder", \
    "/workspaces/SmartOrderApi", \
    "/workspaces/daemon-dotnet" \
]