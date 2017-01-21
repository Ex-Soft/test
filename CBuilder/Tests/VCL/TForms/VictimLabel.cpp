#include "VictimLabel.h"

extern std::fstream File;

TVictimLabel::TVictimLabel(int aSmth, TComponent* Owner) : TImage(Owner)
{
        if(File.is_open() && File.good())
                File<<"TVictimLabel::TVictimLabel()"<<std::endl;
}

TVictimLabel::~TVictimLabel()
{
        if(File.is_open() && File.good())
                File<<"TVictimLabel::~TVictimLabel()"<<std::endl;
}
