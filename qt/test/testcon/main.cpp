#include <iostream>
#include <QtCore/QCoreApplication>
#include <QtSql/QSqlDatabase>
#include <QtSql/QSqlQuery>

using namespace std;

int main(int argc, char *argv[])
{
    QCoreApplication
            a(argc, argv);

    QSqlDatabase
            db=QSqlDatabase::addDatabase("QODBC");

    db.setDatabaseName("ODBC;DSN=fobos_web;DATABASE=CMS_Connect;UID=sa;PWD=developer");
    if(db.open())
    {
        QSqlQuery
           query(QString("select top 10 * from CMS_Connections"),db);

        if(query.isActive())
        {
            if(query.isSelect())
            {
                cout<<"query is a select\n";
                cout<<"query.size()="<<query.size()<<"\n";
                cout<<"query executed: "<<query.executedQuery().toStdString()<<"\n";

                while(query.next())
                {
                    cout<<"Row: "<<query.at()+1<<", ";
                    //cout << query.value(0).toString();
                    /*
                    for(int i = 0; i<fieldcount; ++i)
                    {
                        cout<<query.value(i).toString()<<", ";
                    }
                    */
                    cout<<"\n";
                }
            }
        }

        db.close();
    }
    else
        /* cout<<"Can't open databse "<<db.lastError().text().toStdString()<<"\n" */;

    return a.exec();
}
