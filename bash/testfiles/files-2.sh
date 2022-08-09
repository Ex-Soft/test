#!/bin/bash
find . -type f -name "*.txt" -exec   sed -i "s/Version: [0-9]*\.[0-9]*\.[0-9]*/Version: 3.0.0/" {} +

