//#define TEST_DELETE_SIMPLE_PERMISSION

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace TestSharePointSecurity
{
    class Program
    {
        static void Main(string[] args)
        {
            const string
                requestUrl = "http://nozhenko-s8k/",
                SPWeb = "DocNet",
                SPListName = "Чернетки внутрішніх документів"; // "Додатки до службових записок"; // "Внутрішні документи"; // "Вхідні документи [v2]"; // "Задачі";

            string
                separator = new string('-', 60);

            using(SPSite spSite = new SPSite(requestUrl))
            {
                SPWeb
                    spWeb = spSite.AllWebs[SPWeb];

                #if TEST_DELETE_SIMPLE_PERMISSION
                    TestDeleteSimplePermission(spWeb);
                #endif

                ShowRoleAssignments(spSite.AllWebs[SPWeb].Lists["Види вхідних документів"]);
                ShowRoleAssignments(spSite.AllWebs[SPWeb].Lists["Види наказів"]);

                SPUser
                    checkUser = null;

                Console.WriteLine("AllUsers");
                foreach (SPUser _spUser_ in spWeb.AllUsers)
                {
                    if (_spUser_.LoginName.ToLower() == "softline\\nozhenko")
                        checkUser = _spUser_;

                    Console.WriteLine("{{ID: {0}, Name: {1}, LoginName: {2}}}", _spUser_.ID, _spUser_.Name, _spUser_.LoginName);
                }
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Groups");
                foreach (SPGroup _spGroup_ in spWeb.Groups)
                    Console.WriteLine("{{ID: {0}, Name: {1}}}", _spGroup_.ID, _spGroup_.Name);
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("RoleDefinitions");
                foreach (SPRoleDefinition _spRoleDefinition in spWeb.RoleDefinitions)
                    Console.WriteLine("{{Id: {0}, Name: {1}, Type: {2}}}", _spRoleDefinition.Id, _spRoleDefinition.Name, _spRoleDefinition.Type);
                Console.WriteLine();
                Console.WriteLine();

                SPRoleDefinition
                    spRoleDefinitionManagePermissions = spWeb.RoleDefinitions["DocNet - Керування дозволами"],
                    spRoleDefinitionDelete = spWeb.RoleDefinitions["DocNet - Видалення"];

                SPList
                    spList = spSite.AllWebs[SPWeb].Lists[SPListName];

                foreach (SPPermission spPermission in spList.Permissions)
                {
                    Console.WriteLine("{{Member: {0}, BasePermissions: {1}, PermissionMask: {2}}}", spPermission.Member.ID, spPermission.BasePermissions, spPermission.PermissionMask);
                }

                SPPrincipal
                    spPrincipal;

                SPUser
                    spUser;

                SPGroup
                    spGroup;

                Console.WriteLine("HasUniqueRoleAssignments: {0}", spList.HasUniqueRoleAssignments);
                foreach (SPRoleAssignment spRoleAssignment in spList.RoleAssignments)
                {
                    spPrincipal = spRoleAssignment.Member;
                    if ((spUser = spPrincipal as SPUser) != null)
                        Console.WriteLine("SPUser: {{ID: {0} LoginName: {1}, Name: {2}}}", spUser.ID, spUser.LoginName, spUser.Name);
                    if ((spGroup = spPrincipal as SPGroup) != null)
                        Console.WriteLine("SPGroup: {{ID: {0}, Name: {1}}}", spGroup.ID, spGroup.Name);

                    foreach (SPRoleDefinition spRoleDefinition in spRoleAssignment.RoleDefinitionBindings)
                        Console.WriteLine("{{Id: {0}, Type: {1}, Name: {2}, Description: {3}, BasePermissions: {4}}}",
                                          spRoleDefinition.Id,
                                          spRoleDefinition.Type,
                                          spRoleDefinition.Name,
                                          spRoleDefinition.Description,
                                          spRoleDefinition.BasePermissions);
                    
                }
                Console.WriteLine(separator);
                Console.WriteLine();

                SPRoleAssignment
                    _spRoleAssignment;

                if (!spList.Items[0].HasUniqueRoleAssignments)
                    spList.Items[0].BreakRoleInheritance(false);

                /*
                _spRoleAssignment = new SPRoleAssignment(spWeb.AllUsers["softline\\tester2"]);
                //_spRoleAssignment = spWeb.RoleAssignments.GetAssignmentByPrincipal(spWeb.AllUsers["softline\\tester2"]);
                _spRoleAssignment.RoleDefinitionBindings.Add(spWeb.RoleDefinitions["DocNet - Перегляд"]);
                spList.Items[0].RoleAssignments.Add(_spRoleAssignment);
                */

                foreach (SPListItem item in spList.Items)
                {
                    Console.WriteLine("ID: {0}", item.ID);

                    //Console.WriteLine("{0} {1} ViewListItems: {2} DeleteListItems: {3} ManagePermissions: {4}", item.Title, item["Автор-виконавець"], item.DoesUserHavePermissions(checkUser, SPBasePermissions.ViewListItems), item.DoesUserHavePermissions(checkUser, SPBasePermissions.DeleteListItems), item.DoesUserHavePermissions(checkUser, SPBasePermissions.ManagePermissions)););

                    foreach (SPRoleAssignment spRoleAssignment in item.RoleAssignments)
                    {
                        spPrincipal = spRoleAssignment.Member;
                        if ((spUser = spPrincipal as SPUser) != null)
                            Console.WriteLine("SPUser: {{ID: {0} LoginName: {1}, Name: {2}}}", spUser.ID, spUser.LoginName, spUser.Name);
                        if ((spGroup = spPrincipal as SPGroup) != null)
                            Console.WriteLine("SPGroup: {{ID: {0}, Name: {1}}}", spGroup.ID, spGroup.Name);
                        Console.WriteLine();

                        foreach (SPRoleDefinition spRoleDefinition in spRoleAssignment.RoleDefinitionBindings)
                            Console.WriteLine("{{Id: {0}, Type: {1}, Name: {2}, Description: {3}, BasePermissions: {4}}}",
                                              spRoleDefinition.Id,
                                              spRoleDefinition.Type,
                                              spRoleDefinition.Name,
                                              spRoleDefinition.Description,
                                              spRoleDefinition.BasePermissions);

                        bool
                            IsUpdate = false;

                        if (spRoleAssignment.RoleDefinitionBindings.Contains(spRoleDefinitionManagePermissions))
                        {
                            spRoleAssignment.RoleDefinitionBindings.Remove(spRoleDefinitionManagePermissions);
                            IsUpdate = true;
                        }
                        if (spRoleAssignment.RoleDefinitionBindings.Contains(spRoleDefinitionDelete))
                        {
                            spRoleAssignment.RoleDefinitionBindings.Remove(spRoleDefinitionDelete);
                            IsUpdate = true;
                        }
                        if(IsUpdate)
                            spRoleAssignment.Update();

                        Console.WriteLine();
                    }

                    spUser = spWeb.AllUsers["softline\\tester2"];

                    bool
                        IsExist = false;

                    _spRoleAssignment = null;

                    try
                    {
                        IsExist = (_spRoleAssignment = item.RoleAssignments.GetAssignmentByPrincipal(spUser)) != null;
                    }
                    catch(ArgumentNullException)
                    {
                        IsExist = false;
                    }
                    catch (ArgumentException)
                    {
                        IsExist = false;
                    }

                    if (IsExist)
                    {
                        SPRoleDefinition
                            _spRoleDefinition = _spRoleAssignment.RoleDefinitionBindings[0];

                        if ((_spRoleDefinition.BasePermissions & SPBasePermissions.ViewListItems) != SPBasePermissions.ViewListItems)
                            ;                            
                        if ((_spRoleDefinition.BasePermissions & SPBasePermissions.DeleteListItems) != SPBasePermissions.DeleteListItems)
                            ;                            

                    }

                    Console.WriteLine();
                }

                ShowRoleAssignments(spSite.AllWebs[SPWeb].Lists["Додатки до службових записок"]);
            }

            Console.ReadLine();
        }

        static void ShowRoleAssignments(SPList spList)
        {
            string
                separator = new string('-', 60);

            StreamWriter
                sw = new StreamWriter(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + spList.Title, false, Encoding.GetEncoding(1251));

            sw.AutoFlush = true;

            sw.WriteLine(spList.Title);
            sw.WriteLine();

            sw.WriteLine(ShowRoleAssignments(spList.RoleAssignments));
            foreach (SPListItem item in spList.Items)
            {
                sw.WriteLine("{{ID: {0}, HasUniqueRoleAssignments: {1}}}", item.ID, item.HasUniqueRoleAssignments.ToString().ToLower());
                sw.WriteLine();
                sw.WriteLine(ShowRoleAssignments(item.RoleAssignments));
                sw.WriteLine(separator);
            }
        }

        static string ShowRoleAssignments(SPRoleAssignmentCollection roleAssignments)
        {
            StringBuilder
                output = new StringBuilder();

            foreach (SPRoleAssignment spRoleAssignment in roleAssignments)
            {
                SPUser
                    spUser;

                SPGroup
                    spGroup;

                SPPrincipal
                    spPrincipal = spRoleAssignment.Member;

                if ((spUser = spPrincipal as SPUser) != null)
                    output.Append(string.Format("SPUser: {{ID: {0} LoginName: {1}, Name: {2}}}{3}", spUser.ID, spUser.LoginName, spUser.Name, Environment.NewLine));
                if ((spGroup = spPrincipal as SPGroup) != null)
                    output.Append(string.Format("SPGroup: {{ID: {0}, Name: {1}}}{2}", spGroup.ID, spGroup.Name, Environment.NewLine));

                foreach (SPRoleDefinition spRoleDefinition in spRoleAssignment.RoleDefinitionBindings)
                    output.Append(string.Format("{{Id: {0}, Type: {1}, Name: {2}, Description: {3}, BasePermissions: {4}}}{5}",
                                                spRoleDefinition.Id,
                                                spRoleDefinition.Type,
                                                spRoleDefinition.Name,
                                                spRoleDefinition.Description,
                                                spRoleDefinition.BasePermissions,
                                                Environment.NewLine));
                output.Append(Environment.NewLine);
            }

            return output.ToString();
        }
        #if TEST_DELETE_SIMPLE_PERMISSION
            static void TestDeleteSimplePermission(SPWeb spWeb)
            {
                SPList
                    spList = spWeb.Lists["Чернетки вхідних документів"];

                SPRoleDefinition
                    spRoleDefinitionManagePermissions = spWeb.RoleDefinitions["DocNet - Керування дозволами"],
                    spRoleDefinitionEdit = spWeb.RoleDefinitions["DocNet - Редагування"],
                    spRoleDefinitionDelete = spWeb.RoleDefinitions["DocNet - Видалення"];

                string[]
                    spRoleDefinitionNames = new string[] { spRoleDefinitionManagePermissions.Name, spRoleDefinitionEdit.Name, spRoleDefinitionDelete.Name };

                foreach (SPListItem item in spList.Items)
                    foreach (SPRoleAssignment spRoleAssignment in item.RoleAssignments)
                    {
                        SPPrincipal
                            spPrincipal = spRoleAssignment.Member;

                        foreach (SPRoleDefinition spRoleDefinition in spRoleAssignment.RoleDefinitionBindings)
                            Console.WriteLine("{0} {1} {2}", spPrincipal.Name, spRoleDefinition.Name, spRoleDefinition == spRoleDefinitionManagePermissions || spRoleDefinition == spRoleDefinitionEdit || spRoleDefinition == spRoleDefinitionDelete);
                        Console.WriteLine();

                        List<SPRoleDefinition>
                            roleDefinitions = spRoleAssignment.RoleDefinitionBindings
                            .Cast<SPRoleDefinition>()
                            .Where(definition => spRoleDefinitionNames.Contains(definition.Name))
                            .ToList();
                        roleDefinitions.ForEach(d => Console.WriteLine(d.Name));
                        Console.WriteLine();

                        bool
                            isReverse = true;

                        roleDefinitions = spRoleAssignment.RoleDefinitionBindings
                            .Cast<SPRoleDefinition>()
                            .Where(definition => spRoleDefinitionNames.Contains(definition.Name) ^ isReverse)
                            .ToList();
                        roleDefinitions.ForEach(d => Console.WriteLine(d.Name));
                        Console.WriteLine();

                        isReverse = false;
                        roleDefinitions = spRoleAssignment.RoleDefinitionBindings
                            .Cast<SPRoleDefinition>()
                            .Where(definition => spRoleDefinitionNames.Contains(definition.Name) ^ isReverse)
                            .ToList();
                        roleDefinitions.ForEach(d => Console.WriteLine(d.Name));
                        Console.WriteLine();
                    }
            }
        #endif
    }
}
