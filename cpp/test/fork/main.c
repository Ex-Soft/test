#include <stdio.h>
#include <errno.h>
#include <sys/types.h>
#include <unistd.h>

int main(int argc, char **argv)
{
	pid_t
		pid,
		old_ppid,
		new_ppid,
		child,
		parent;

	printf("getpid() started...\n");	
	parent=getpid();
	printf("getpid() finished (%d)\n", parent);
	
	if((child=fork())<0)
	{
		fprintf(stderr, "%s: fork of child failed: %s\n", argv[0], strerror(errno));
		exit(1);
	}
	else if(child==0)
	{
		old_ppid=getpid();
		sleep(2);
		new_ppid=getpid();
	}
	else
	{
		sleep(1);
		exit(0);
	}
	
	printf("Original parent: %d\n", parent);
	printf("Child: %d\n", getpid());
	printf("Child's old ppid: %d\n", old_ppid);
	printf("Child's new ppid: %d\n", new_ppid);
	
	exit(0);
}
