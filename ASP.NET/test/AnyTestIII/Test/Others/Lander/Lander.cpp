#using <system.dll>
#using <mscorlib.dll>
#using <system.web.dll>

using namespace System;
using namespace System::Web::UI;
using namespace System::Web::UI::WebControls;

public __gc class LanderPage:public Page
{
   protected:
     static const double
       gravity=1.625,
       landermass=17198;

     Label
       *Altitude,
       *Velocity,
       *Acceleration,
       *Fuel,
       *ElapsedTime,
       *Output;

     TextBox
       *Throttle,
       *Seconds;

   public:
   void OnCalculate(Object *sender, EventArgs *argv)
   {
      try
        {
           double
             alt1=Convert::ToDouble(Altitude->Text);

           if(alt1>0)
             {
                if(Throttle->Text->Length==0)
                  {
                     Output->Text="Error: Required field missing";
                     return;
                  }

                if(Seconds->Text->Length==0)
                  {
                     Output->Text="Error: Required field missing";
                     return;
                  }

                double
                  throttle=Convert::ToDouble(Throttle->Text),
                  sec=Convert::ToDouble(Seconds->Text);

                if(throttle<0 || throttle>100)
                  {
                     Output->Text="Error: Invalid throttle value";
                     return;
                  }

                if(sec<=0)
                  {
                     Output->Text="Error: Invalid burn time";
                     return;
                  }

                double
                  vel1=Convert::ToDouble(Velocity->Text),
                  fuel1=Convert::ToDouble(Fuel->Text),
                  time1=Convert::ToDouble(ElapsedTime->Text),
                  thrust=throttle*1200,
                  fuel=(thrust*sec)/2600,
                  fuel2=fuel1-fuel;

                if(fuel<0)
                  {
                     Output->Text="Error: Insufficient fuel";
                     return;
                  }

                 Output->Text="";

                 double
                   avgmass=landermass+((fuel1+fuel2)/2),
                   force=thrust-(avgmass*gravity),
                   acc=force/avgmass,
                   vel2=vel1+(acc*sec),
                   avgvel=(vel1+vel2)/2,
                   alt2=alt1+(avgvel*sec),
                   time2=time1+sec;

                 if(alt2<=0)
                   {
                      double
                        mul=alt1/(alt1-alt2);

                      vel2=vel1-((vel1-vel2)*mul);
                      alt2=0;
                      fuel2=fuel1-((fuel1-fuel2)*mul);
                      time2=time1-((time1-time2)*mul);

                      if(vel2>=-4)
                        Output->Text="The Eagle has landed";
                      else
                        Output->Text="Kaboom!";
                   }

                 Altitude->Text=(new Double (alt2))->ToString("f1");
                 Velocity->Text=(new Double (vel2))->ToString("f1");
                 Acceleration->Text=(new Double (acc))->ToString("f1");
                 Fuel->Text=(new Double (fuel2))->ToString("f1");
                 ElapsedTime->Text=(new Double(time2))->ToString("f1");
             }
        }
      catch(Exception *eException)
        {
           Output->Text=eException->Message;
        }
   }
};