#!/bin/bash

# https://www.cyberciti.biz/faq/how-to-show-recursive-directory-listing-on-linux-or-unix/

ls -R -a /c/dell
find /c/dell -print
find /c/dell/ -ls
du -a /c/dell