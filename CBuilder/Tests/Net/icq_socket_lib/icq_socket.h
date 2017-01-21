/*=============================================================
 *
 *  Copyright (C) 1999-2002 Soft Variant Company.
 *  All Rights Reserved.
 *
 *  Author: Evgeny Golovin.
 *  E-Mail: softvariant@chat.ru
 *  Homepage: http://softvariant.boom.ru/icq_socket/index.htm
 *
 **************************************************************/

#ifndef __ICQ_SOCKET_H__ 
#define __ICQ_SOCKET_H__ 

#include "icq_type.h"

// ====================================================
// Библиотека ICQ_Socket поможет Вам интегрировать в
// программы возможности общения друг с другом, используя 
// все прелести протокола ICQ.
// ====================================================
// Способ распространения - shareware. 
// Незарегистрированная версия библиотеки работает 
// неограниченное время, но некоторые функции заблокированы. 
// Чтобы открыть все функции библиотеки, Вам нужно купить 
// регистрационный ключ. Для этого посетите сайт:
// ====================================================
// http://softvariant.narod.ru/icq_socket/index.htm
// ====================================================
// По всем вопросам обращайтесь на softvariant@narod.ru
// Ваше мнение очень важно для улучшения данной библиотеки.
// ====================================================
// Все функции можно вызывать из разных покотов
// при возникновении одновременного доступа, второй
// поток будет ждать, пока первый не завершит операцию
// ====================================================

// Получить номер версии библиотеки, запакованый следующим образом:
// (BYTE*)[3] = ICQ_VERSION_GENERAL - для всех совместимых версий одинаковое
// (BYTE*)[2] = ICQ_VERSION_MAJOR   - версия библиотеки
// (BYTE*)[1] = ICQ_VERSION_MINOR   - модификация
// (BYTE*)[0] = ICQ_VERSION_SUB     - изменения, флаги и лицензия
// если бит 0 выкл. - не зарегистрированная версия
// если бит 1 выкл. - бета версия
ICQ_SOCKET_API DWORD __cdecl ICQ_GetLibVersion();

// Получить номер лицензии, 0 - библиотека не зарегистрирована
ICQ_SOCKET_API DWORD __cdecl ICQ_GetLicense();

// Зарегистрировать библиотеку. 
// Способ вызова этой функции Вы получаете при покупке (регистрации).
// Если возвращает true и регистрационный номер верен,
// то закрытые функции становятся доступными. 
// Ключ проверяется на контрольную сумму по очень хитрому
// алгоритму, что делает не возможным ввод поддельного ключа. 
//BOOL __cdecl ICQ_Register(WORD,WORD,WORD,WORD);

// Index начиная с 0, поддерживаемая версия протокола ICQ
// конец списка: -1
ICQ_SOCKET_API long __cdecl ICQ_GetPacketVersion(DWORD Index);

// Максимальное количество ICQ сокетов, которые Вы можете 
// создать функцией ICQ_NewSocket
ICQ_SOCKET_API DWORD __cdecl ICQ_GetMaxSocketCount();

// Текущее количество сокетов, созданных функцией ICQ_NewSocket
ICQ_SOCKET_API DWORD __cdecl ICQ_GetSocketCount();

// Проверка совместимости версии, передаваемой в парамре, 
// с версией текущей библиотеки. Если 0, то версия библиотеки не
// совместима с версией Major,Minor
ICQ_SOCKET_API BOOL __cdecl ICQ_CheckVersion(DWORD Major,DWORD Minor);

// Для всех сокетов вызывать функцию, пока она возвращает True,
// передавая ей парамерт void * P
ICQ_SOCKET_API DWORD __cdecl ICQ_ForEach(BOOL (__cdecl*F)(ICQ_Socket,void*),void * P);

// -------------------------------------------------------------

// Создать сокет. После этого Вы можете использовать его во всех
// остальных функциях, где нужен тип ICQ_Socket. Если данная функция 
// возвращает ICQ_Invalid_Socket, то произошла ошибка. Не забудьте
// удалить сокет после завершение его использования функцией ICQ_DeleteSocket
ICQ_SOCKET_API ICQ_Socket __cdecl ICQ_NewSocket(); 

// Удалить сокет. После этого Вы не можете использовать его.
ICQ_SOCKET_API void __cdecl ICQ_DeleteSocket(ICQ_Socket); 

// -------------------------------------------------------------
// С В О Й С Т В А

// Если в описании функции имеется слово "online",
// то это означает, что изменения происходят не зависимо
// от того, подключены Вы в данный момент или нет,
// в обратном случае, происходит отключение от сервера!

// При возникновении ряда событий, вызывается функция, 
// определенная пользователем, см. ICQ_Callback

// Установить события пользователя для всех сокетов (online)
ICQ_SOCKET_API void __cdecl ICQ_SetStdCallback(ICQ_Callback * Callback);
ICQ_SOCKET_API ICQ_Callback * __cdecl ICQ_GetStdCallback();

// Установить события пользователя для конкретного сокета (online)
ICQ_SOCKET_API void __cdecl ICQ_SetCallback(ICQ_Socket,ICQ_Callback*);
ICQ_SOCKET_API ICQ_Callback * __cdecl ICQ_GetCallback(ICQ_Socket);

// -------------------------------------------------------------
// Установить версию протокола ICQ. Вы можете получить список поддерживаемых
// протоколов функцией ICQ_GetPacketVersion
ICQ_SOCKET_API void __cdecl ICQ_SetProtocolVersion(ICQ_Socket,long);
ICQ_SOCKET_API long __cdecl ICQ_GetProtocolVersion(ICQ_Socket);

// Подключиться (отключиться) к серверу, если WaitConnect == true, то ожидает соединения
ICQ_SOCKET_API void __cdecl ICQ_SetActive(ICQ_Socket,BOOL);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetActive(ICQ_Socket);

// Если true, то сокет находится в процессе подключения
ICQ_SOCKET_API BOOL __cdecl ICQ_GetConnecting(ICQ_Socket);

// Если true, то функции соединения будут ожидать подключения (online)
ICQ_SOCKET_API void __cdecl ICQ_SetWaitConnect(ICQ_Socket,BOOL);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetWaitConnect(ICQ_Socket);

// Если true, то при необходимости будет происходить
// автоматическое подключение к серверу (online)
ICQ_SOCKET_API void __cdecl ICQ_SetAutoConnect(ICQ_Socket,BOOL);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetAutoConnect(ICQ_Socket);

// Установить сервер ICQ. Может быть и IP адресс вида "A.B.C.D"
// Адрес может заканчиваться портом, например "login.icq.com:5190"
ICQ_SOCKET_API void __cdecl ICQ_SetHost(ICQ_Socket,const char*);
ICQ_SOCKET_API char * __cdecl ICQ_GetHost(ICQ_Socket);

// Установить порт сервера ICQ
ICQ_SOCKET_API void __cdecl ICQ_SetHostPort(ICQ_Socket,long);
ICQ_SOCKET_API long __cdecl ICQ_GetHostPort(ICQ_Socket);

// Установить Ваш ICQ номер
ICQ_SOCKET_API void __cdecl ICQ_SetUIN(ICQ_Socket,DWORD);
ICQ_SOCKET_API DWORD __cdecl ICQ_GetUIN(ICQ_Socket);

// Установить Ваш ник
ICQ_SOCKET_API void __cdecl ICQ_SetNick(ICQ_Socket,const char*);
ICQ_SOCKET_API char * __cdecl ICQ_GetNick(ICQ_Socket);

// Установить Ваш пароль
ICQ_SOCKET_API void __cdecl ICQ_SetPass(ICQ_Socket,const char*);
ICQ_SOCKET_API char * __cdecl ICQ_GetPass(ICQ_Socket);

// Установить максимальную длину пароля
ICQ_SOCKET_API void __cdecl ICQ_SetMaxPassLen(ICQ_Socket,long);
ICQ_SOCKET_API long __cdecl ICQ_GetMaxPassLen(ICQ_Socket);

// Установить использование прокси сервера. Если true, тоиспользуется
ICQ_SOCKET_API void __cdecl ICQ_SetProxyUsed(ICQ_Socket S,BOOL Value);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetProxyUsed(ICQ_Socket S);

// Установить прокси сервер (см. описание ICQ_SetHost)
ICQ_SOCKET_API void __cdecl ICQ_SetProxyHost(ICQ_Socket,const char*);
ICQ_SOCKET_API char * __cdecl ICQ_GetProxyHost(ICQ_Socket);

// Установить порт прокси сервера
ICQ_SOCKET_API void __cdecl ICQ_SetProxyPort(ICQ_Socket,long);
ICQ_SOCKET_API long __cdecl ICQ_GetProxyPort(ICQ_Socket);

// Установить использование аутентификации прокси сервера
ICQ_SOCKET_API void __cdecl ICQ_SetProxyLoginUsed(ICQ_Socket S,BOOL Value);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetProxyLoginUsed(ICQ_Socket S);

// Установить пользователя прокси сервера для аутентификации
ICQ_SOCKET_API void __cdecl ICQ_SetProxyUser(ICQ_Socket,const char*);
ICQ_SOCKET_API char * __cdecl ICQ_GetProxyUser(ICQ_Socket);

// Установить пароль пользователя прокси сервера 
// для аутентификации
ICQ_SOCKET_API void __cdecl ICQ_SetProxyPass(ICQ_Socket,const char*);
ICQ_SOCKET_API char * __cdecl ICQ_GetProxyPass(ICQ_Socket);

// Установить состояние (online)
ICQ_SOCKET_API void __cdecl ICQ_SetStatus(ICQ_Socket,ICQ_Status);
ICQ_SOCKET_API ICQ_Status __cdecl ICQ_GetStatus(ICQ_Socket);

// Установить уровень сообщений для отладки (online)
ICQ_SOCKET_API void __cdecl ICQ_SetLogLevel(ICQ_Socket,ICQ_Log);
ICQ_SOCKET_API ICQ_Log __cdecl ICQ_GetLogLevel(ICQ_Socket);

// ===== ДЛЯ СОВМЕСТИМОСТИ С ПРОШЛЫМИ ВЕРСИЯМИ ===== 
ICQ_SOCKET_API void __cdecl ICQ_SetTimeout(ICQ_Socket,long);
ICQ_SOCKET_API long __cdecl ICQ_GetTimeout(ICQ_Socket);

// ===== ДЛЯ СОВМЕСТИМОСТИ С ПРОШЛЫМИ ВЕРСИЯМИ ===== 
ICQ_SOCKET_API void __cdecl ICQ_SetMaxAttempts(ICQ_Socket,long);
ICQ_SOCKET_API long __cdecl ICQ_GetMaxAttempts(ICQ_Socket);

// Установить указатель пользователя (online)
// использовать для связи ICQ_Socket с др. данными
ICQ_SOCKET_API void __cdecl ICQ_SetUserPointer(ICQ_Socket,void*);
ICQ_SOCKET_API void * __cdecl ICQ_GetUserPointer(ICQ_Socket);

// Установить указатель в функции Wait (см. ICQ_Callback) (online)
ICQ_SOCKET_API void __cdecl ICQ_SetWaitPointer(ICQ_Socket,void*);
ICQ_SOCKET_API void * __cdecl ICQ_GetWaitPointer(ICQ_Socket);

// Статус ожидания, если да, то сокет обрабатывается в
// функции ICQ_Wait (online)
ICQ_SOCKET_API BOOL __cdecl ICQ_GetWait(ICQ_Socket);

// Общее время ожидания в милисекундах
ICQ_SOCKET_API DWORD __cdecl ICQ_GetWaitTimeout(ICQ_Socket);

// Получить причину отключения. Особенно полезно использовать
// в событиях Disconnecting и Disconnected. возвращает
// значения ICQ_DisconnectReason_ ...
ICQ_SOCKET_API long __cdecl ICQ_GetDisconnectReason(ICQ_Socket S);

// Сбросить статус отключения. Есть смысл использовать с событиях
// Disconnecting и Disconnected при статусе
// ICQ_DisconnectReason_InvalidUIN, ICQ_DisconnectReason_InvalidPassword
// ICQ_DisconnectReason_Redirect. Например, если при подключении к серверу
// произошла переадресация, можно отчистить статус для прекращения подключения
ICQ_SOCKET_API void __cdecl ICQ_ClearDisconnectReason(ICQ_Socket S);

// Количество переадресаций, например 1 - одна переадресация (при
// подключении используются свойства RedirectHost и RedirectPort),
// 0 - не было переадресаций и подключение происходит по свойствам
// Host и HostPort
ICQ_SOCKET_API long __cdecl ICQ_GetRedirectCount(ICQ_Socket S);

// Хост переадресации
ICQ_SOCKET_API char * __cdecl ICQ_GetRedirectHost(ICQ_Socket S);
// Порт переадресации
ICQ_SOCKET_API long __cdecl ICQ_GetRedirectPort(ICQ_Socket S);

// Если была переадресация, то возвращает RedirectHost, иначе Host
ICQ_SOCKET_API char * __cdecl ICQ_GetConnectHost(ICQ_Socket S);
// Если была переадресация, то возвращает RedirectPort, иначе HostPort
ICQ_SOCKET_API long __cdecl ICQ_GetConnectPort(ICQ_Socket S);

// ===== ДЛЯ СОВМЕСТИМОСТИ С ПРОШЛЫМИ ВЕРСИЯМИ ===== 
ICQ_SOCKET_API DWORD __cdecl ICQ_GetLastSendUDPSequence(ICQ_Socket);

// -------------------------------------------------------------
// работа над списком контактов. Эти функции не посылают данные по сети

// Количество контактов
ICQ_SOCKET_API DWORD __cdecl ICQ_GetContactCount(ICQ_Socket);

// Получить индекс контакта по ICQ номеру (номер контакта начинается с 0)
ICQ_SOCKET_API long __cdecl ICQ_GetUINContactIndex(ICQ_Socket,DWORD UIN);

// Получить информацию о контакте по его индексу
ICQ_SOCKET_API ICQ_Contact * __cdecl ICQ_GetIndexContact(ICQ_Socket,DWORD Index);

// Получить информацию о контакте по ICQ номеру 
ICQ_SOCKET_API ICQ_Contact * __cdecl ICQ_GetUINContact(ICQ_Socket,DWORD UIN);

// Старый вариант, см. ICQ_SetContact2
ICQ_SOCKET_API void __cdecl ICQ_SetContact(ICQ_Socket,DWORD UIN,BOOL Visible);

// Добавить или изменить контакт. 
// Параметр Visible контролирует нахождение контакта в видимом списке
// Параметр Invisible контролирует нахождение контакта в невидимом списке
ICQ_SOCKET_API void __cdecl ICQ_SetContact2(ICQ_Socket,DWORD UIN,BOOL Visible,BOOL Invisible);

// Удалить контакт по его индексу
ICQ_SOCKET_API void __cdecl ICQ_DeleteIndexContact(ICQ_Socket S,DWORD Index);
ICQ_SOCKET_API void __cdecl ICQ_RemoveIndexContact(ICQ_Socket S,DWORD Index); // old

// Удалить контакт по ICQ номеру 
ICQ_SOCKET_API void __cdecl ICQ_DeleteUINContact(ICQ_Socket S,DWORD UIN);
ICQ_SOCKET_API void __cdecl ICQ_RemoveUINContact(ICQ_Socket S,DWORD UIN); // old

// Отчистить список контактов
ICQ_SOCKET_API void __cdecl ICQ_ClearContactList(ICQ_Socket);

// -------------------------------------------------------------
// Подключиться к серверу. Если все соответствующие совйства установлены,
// то используйте свойтсво Active для этой же цели
ICQ_SOCKET_API long __cdecl ICQ_Connect(ICQ_Socket,
  const char * Host,long Port,ICQ_Status,DWORD UIN,const char * Nick,const char * Pass);

// Отключиться от сервера
ICQ_SOCKET_API void __cdecl ICQ_Disconnect(ICQ_Socket);

// -------------------------------------------------------------

// Сетевая функция для всех открытых сокетов, см. ICQ_PollSocket
ICQ_SOCKET_API void __cdecl ICQ_Poll();

// Сетевая функция для сокета.
// Должна вызываться для обработки событий в сети 
// (прием сообщений, подключения, отправка подтверждений на сервер и тд)
ICQ_SOCKET_API void __cdecl ICQ_PollSocket(ICQ_Socket);

// -------------------------------------------------------------
// -------------------------------------------------------------
// -------------------------------------------------------------
// -------------------------------------------------------------
// Далее идут функции отправки данных по сети. Все такие функции 
// начинаются с ICQ_Send_. Результатом выполнения являются следующие
// значения:
//   ICQ_Result_OK - корректное завершение, пакет был отправлен
//   ICQ_Result_Error - произошла ошибка при посылке пакета. 
//     Нужно отметить, что при возврате этого значения, сокет 
//     уже находится в отключеном состоянии
//   ICQ_Result_Void - данная функция не поддерживается в данной
//     версии библиотеки
// -------------------------------------------------------------
// -------------------------------------------------------------
// -------------------------------------------------------------
// -------------------------------------------------------------


// Запросить инфу. Результат ждите в событии UserInfo
ICQ_SOCKET_API long __cdecl ICQ_Send_GetInfo(ICQ_Socket,DWORD UIN);

// ===== ДЛЯ СОВМЕСТИМОСТИ С ПРОШЛЫМИ ВЕРСИЯМИ ===== 
ICQ_SOCKET_API long __cdecl ICQ_Send_GetExtInfo(ICQ_Socket,DWORD UIN);

// Запросить мета инфу. Результат ждите в событиях:
//   MetaUserInfo2, MetaUserMore, MetaUserWork, MetaUserAbout, 
//   MetaUserInterests, MetaUserAffiliations
ICQ_SOCKET_API long __cdecl ICQ_Send_GetMetaInfo(ICQ_Socket,DWORD UIN);

// -------------------------------------------------------------

// Отправить сообщение
// ===== ЭТА ФУНКЦИЯ ДОСТУПНА ТОЛЬКО В ПОЛНОЙ ВЕРСИИ ===== 
// В качестве последнего параметра используйте ICQ_Send_ThruServer
ICQ_SOCKET_API long __cdecl ICQ_Send_Message(ICQ_Socket,DWORD UIN,const char * Text,ICQ_Send);

// Отправить url
// В качестве последнего параметра используйте ICQ_Send_ThruServer
ICQ_SOCKET_API long __cdecl ICQ_Send_Url(ICQ_Socket,DWORD UIN,const char * Url,const char * Desc,ICQ_Send);

// Искать пользователя. Если поле не ведено, то 
// используйте "" для строковых параметров и 0 для численных. 
// Ждите MetaUserFound для формирования результата поиска и 
// MetaEndFound для завершения процесса
ICQ_SOCKET_API long __cdecl ICQ_Send_Search(ICQ_Socket,DWORD UIN,
     const char * Email,const char * Nick,
     const char * FirstName,const char * LastName);

// Искать пользователя по расширенной информации. Если поле не ведено, то 
// используйте "" для строковых параметров и 0 для численных. 
// Ждите MetaUserFound для формирования результата поиска и 
// MetaEndFound для завершения процесса
ICQ_SOCKET_API long __cdecl ICQ_Send_FullSearch2(ICQ_Socket S,
    const char * Email,const char * Nick,
    const char * FirstName,const char * LastName,
    DWORD MinAge,DWORD MaxAge,ICQ_Gender Gender,
    DWORD Lang,const char * City,const char * State,DWORD Country,
    const char * Company,const char * Department,const char * Job,
    DWORD Occupation,
    DWORD Background,const char * BackgroundDesc,
    DWORD Interests,const char * InterestsDesc,
    DWORD Affiliation,const char * AffiliationDesc,
    DWORD Homepage,const char * HomepageDesc,
    BOOL Online);

ICQ_SOCKET_API long __cdecl ICQ_Send_FullSearch(ICQ_Socket S,
    const char * Email,const char * Nick,
    const char * FirstName,const char * LastName,
    DWORD MinAge,DWORD MaxAge,ICQ_Gender Gender,
    DWORD Lang,const char * City,const char * State,DWORD Country,
    const char * Company,const char * Department,const char * Job,
    DWORD Occupation,
    DWORD Background,const char * BackgroundDesc,
    DWORD Affiliation,const char * AffiliationDesc,
    DWORD Homepage,const char * HomepageDesc,
    BOOL Online);

// Пока не поддерживается
// ===== ЭТА ФУНКЦИЯ ДОСТУПНА ТОЛЬКО В ПОЛНОЙ ВЕРСИИ ===== 
ICQ_SOCKET_API long __cdecl ICQ_Send_KeepAlive(ICQ_Socket);

// Послать на сервер список контактов
ICQ_SOCKET_API long __cdecl ICQ_Send_ContactList(ICQ_Socket);
ICQ_SOCKET_API long __cdecl ICQ_Send_VisibleList(ICQ_Socket);
ICQ_SOCKET_API long __cdecl ICQ_Send_InvisibleList(ICQ_Socket);

// Послать положительный ответ на запрос добавления Вас в список контактов
// Устаревший вариант, см. ICQ_Send_AllowRequest и ICQ_Send_DeniedRequest
ICQ_SOCKET_API long __cdecl ICQ_Send_Authorize(ICQ_Socket,DWORD UIN);

// -------------------------------------------------------------
// Послать положительный ответ на запрос. Необходимо использовать
// в событиях ProcessChatRequest, ProcessFileRequest, ProcessAuthRequest.
// В данный момент реализован механизм ответа только на событие ProcessAuthRequest
ICQ_SOCKET_API long __cdecl ICQ_Send_AllowRequest(ICQ_Socket);

// Послать отрицательный ответ на запрос. Необходимо использовать
// в событиях ProcessChatRequest, ProcessFileRequest, ProcessAuthRequest.
// В данный момент реализован механизм ответа только на событие ProcessAuthRequest
ICQ_SOCKET_API long __cdecl ICQ_Send_DeniedRequest(ICQ_Socket);

// -------------------------------------------------------------
// Функции установки параметров. Пока не реализованы.

ICQ_SOCKET_API long __cdecl ICQ_Send_SetAuth(ICQ_Socket S,ICQ_Auth Auth);

ICQ_SOCKET_API long __cdecl ICQ_Send_SetUserInfo(ICQ_Socket, 
  const char * Nick,const char * First,const char * Last, 
  const char * Email);

ICQ_SOCKET_API long __cdecl ICQ_Send_SetMetaInfo2(ICQ_Socket S, 
  const char * Nick,const char * First,const char * Last, 
  const char * Email,const char * Email2,const char * Email3, 
  const char * City,const char * State,const char * Phone, 
  const char * Fax,const char * Street,const char * Cellular, 
  DWORD Zip,DWORD CountryCode,float TimeOffset,BOOL HideEmail);

// old version
ICQ_SOCKET_API long __cdecl ICQ_Send_SetMetaInfo(ICQ_Socket, 
  const char * Nick,const char * First,const char * Last, 
  const char * Email,const char * Email2,const char * Email3, 
  const char * City,const char * State,const char * Phone, 
  const char * Fax,const char * Street,const char * Cellular, 
  DWORD Zip,DWORD CountryCode,DWORD CountryStat,BOOL HideEmail);

// для совместимости, изменяет пол на "не установлен"
// пользуйтесь ICQ_Send_SetMetaInfoMore
ICQ_SOCKET_API long __cdecl ICQ_Send_SetMetaInfoHome(ICQ_Socket,
  DWORD Age,const char * HomePage,
  DWORD Year,DWORD Month,DWORD Day,
  DWORD Lang1,DWORD Lang2,DWORD Lang3);

// если возраст не "известен", то Age равен 0xFFFF
ICQ_SOCKET_API long __cdecl ICQ_Send_SetMetaInfoMore(ICQ_Socket,
  DWORD Age,ICQ_Gender Gender,const char * HomePage,
  DWORD Year,DWORD Month,DWORD Day,
  DWORD Lang1,DWORD Lang2,DWORD Lang3);

ICQ_SOCKET_API long __cdecl ICQ_Send_SetMetaInfoAbout(ICQ_Socket,
  const char * About);

ICQ_SOCKET_API long __cdecl ICQ_Send_SetMetaInfoSecurity(ICQ_Socket,
  ICQ_Auth,BOOL Web,BOOL HideIp);

// -------------------------------------------------------------
//misc

// ждать завершения предыдущей операции
// ===== ДЛЯ СОВМЕСТИМОСТИ С ПРОШЛЫМИ ВЕРСИЯМИ ===== 
ICQ_SOCKET_API long __cdecl ICQ_Wait(ICQ_Socket);

ICQ_SOCKET_API long __cdecl ICQ_WaitTimeout(ICQ_Socket,DWORD);
// ================================================================
// default: 12 = english

ICQ_SOCKET_API char * __cdecl ICQ_GetCountry(DWORD Key,DWORD Lang = 12);

// return true if key is unsigned
ICQ_SOCKET_API BOOL __cdecl ICQ_GetCountryRange(DWORD& Min,DWORD& Max);

ICQ_SOCKET_API char * __cdecl ICQ_GetOccupation(DWORD Key,DWORD Lang = 12);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetOccupationRange(DWORD& Min,DWORD& Max);

ICQ_SOCKET_API char * __cdecl ICQ_GetBackground(DWORD Key,DWORD Lang = 12);                              
ICQ_SOCKET_API BOOL __cdecl ICQ_GetBackgroundRange(DWORD& Min,DWORD& Max);

ICQ_SOCKET_API char * __cdecl ICQ_GetAffiliation(DWORD Key,DWORD Lang = 12);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetAffiliationRange(DWORD& Min,DWORD& Max);

ICQ_SOCKET_API char * __cdecl ICQ_GetLanguage(DWORD Key,DWORD Lang = 12);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetLanguageRange(DWORD& Min,DWORD& Max);

ICQ_SOCKET_API char * __cdecl ICQ_GetInterest(DWORD Key,DWORD Lang = 12);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetInterestRange(DWORD& Min,DWORD& Max);

#endif
