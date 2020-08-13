#!/usr/bin/env sh
set -e
cd ${BASEDIR}

if [ -f "jsonnetfile.lock.json" ] || [ -f "jsonnetfile.json" ]; then
  installed_hash=""
  if [ -f "vendor/.installed.hash" ]	; then
    installed_hash="$(cat vendor/.installed.hash)"
  fi
  current_hash="$(sha256sum jsonnetfile.lock.json | cut -d " " -f 1)"
  if [[ "${current_hash}" != "${installed_hash}" ]]; then
    jb install &>/dev/null
    echo -n "${current_hash}" > vendor/.installed.hash
  fi
fi

exec jsonnet -J vendor "$@"
