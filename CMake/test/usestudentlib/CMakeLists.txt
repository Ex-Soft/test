cmake_minimum_required(VERSION 3.5)
project (TestLibrary)

#For the shared library:
set ( PROJECT_LINK_LIBS libtestStudent.so )
link_directories( ../studentlib_shared/build )

#For the static library:
#set ( PROJECT_LINK_LIBS libtestStudent.a )
#link_directories( ../studentlib_static/build )

include_directories( ../studentlib_shared/include )

add_executable(libtest libtest.cpp)
target_link_libraries( libtest ${PROJECT_LINK_LIBS} )
