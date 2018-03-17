class CBase
{
private:
 virtual void func()=0;
};

class CDerived : public CBase
{
public:
 virtual void func()
 {
 }
};

class CBaseII
{
private:
 virtual void func()
 {}
};

class CDerivedII : public CBaseII
{
public:
 virtual void func()
 {
 }
};

int main(int argc, char **argv)
{
    CDerived
        d = CDerived();

    d.func();

    CDerivedII
        dII = CDerivedII();

    dII.func();

	return 0;
}
