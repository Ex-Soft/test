import com.google.gson.Gson;

import java.util.Date;

public class TestJson {
    public static void main(String[] args)
    {
        Victim
            victimSrc = new Victim(),
            victimDest;

        victimSrc._date = new Date(119, 1, 4);

        Gson gson = new Gson();

        String tmpString = gson.toJson(victimSrc);
        victimDest = gson.fromJson(tmpString, Victim.class);
    }
}
