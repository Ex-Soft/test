int main(int argc, char **argv)
{
    int i = 0;
    const int *pci = &i;

    //*pci = 10; //Error C3892: 'pi' : you cannot assign to a variable that is const

    //int *j = pi; // error C2440: 'initializing' : cannot convert from 'const int *' to 'int *'
    int *j = const_cast<int *>(pci);
    *j = 10;

    int *pi = &i;
    void *vp=pi;
    //char *pch = vp; // error C2440: 'initializing' : cannot convert from 'void *' to 'char *'
    char *pch = static_cast<char *>(vp);

    unsigned ui;
    unsigned *v_ptr = &ui;
    //pi=v_ptr; // error C2440: '=' : cannot convert from 'unsigned int *' to 'int *'
    //pi = static_cast<int *>(v_ptr); // error C2440: 'static_cast' : cannot convert from 'unsigned int *' to 'int *'
    pi = reinterpret_cast<int *>(v_ptr);

    return 0;
}
