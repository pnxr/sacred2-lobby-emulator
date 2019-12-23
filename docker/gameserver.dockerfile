FROM debian:buster-slim
MAINTAINER xrystal@regxr.eu

ARG DEBIAN_FRONTEND=noninteractive

#install wine and cleanup apt afterwards
RUN dpkg --add-architecture i386 \
        && apt-get update \
        && apt-get install -y --no-install-recommends wine wine32 \
        && rm -rf /var/lib/apt/lists/* \
        && useradd -ms /bin/bash contained

#do not run wine as root
USER contained
