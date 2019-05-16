using KZVL_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KZVL_Core.Data
{
    public class DbInitializer
    {
        public static void Initialize(KZVLContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Roles.Any())
            {
                return;   // DB has been seeded
            }
            #region Role
            var roles = new Role[]
            {
            new Role{Name="Diagonalus" },
            new Role{Name="Perviy Temp" },
            new Role{ Name="Vtoroy Temp" },
            new Role{ Name="Libero"},
            new Role{Name="Passer"}
           
            };
            foreach (Role s in roles)
            {
                context.Roles.Add(s);
            }
            context.SaveChanges();
            #endregion

            #region Divizions
            var divizions = new Divizion[]
            {
            new Divizion{Number=1},
            new Divizion{Number=2},
            new Divizion{Number=3},
            new Divizion{Number=4}

            };
            foreach (Divizion c in divizions)
            {
                context.Divizions.Add(c);
            }
            context.SaveChanges();
            #endregion

            #region Group
            var groups = new Group[]
            {
                    new Group{Name="A", DivizionID=divizions.Single(i=>i.Number==1).ID},
                    new Group{Name="B", DivizionID=divizions.Single(i=>i.Number==1).ID},
                    new Group{Name="C", DivizionID=divizions.Single(i=>i.Number==2).ID},
                    new Group{Name="D", DivizionID=divizions.Single(i=>i.Number==2).ID},
                    new Group{Name="E", DivizionID=divizions.Single(i=>i.Number==3).ID},
            };
            foreach (Group e in groups)
            {
                context.Groups.Add(e);
            }
            context.SaveChanges();
            #endregion

            #region Team
            var teams = new Team[]
            {
                    new Team{Name="Meridian", GroupId=groups.Single(i=>i.Name=="A").ID, Rating=12},
                    new Team{Name="Boryspil", GroupId=groups.Single(i=>i.Name=="A").ID, Rating=10},
                    new Team{Name="Temp", GroupId=groups.Single(i=>i.Name=="B").ID, Rating=8},
            };
            foreach (Team e in teams)
            {
                context.Teams.Add(e);
            }
            context.SaveChanges();
            #endregion

            #region Players
            var players = new Player[]
            {
                    new Player{Number=10, Name="Eugene Romanenko",Height=192,RoleId=roles.Single(i=>i.Name=="Perviy Temp").Id,TeamId=teams.Single(i=>i.Name=="Meridian").Id,CountOfTheBestPlayer=3,Category="KMS", Birth=new DateTime(2000,3,16), IsCaptain=false, IsBestGroupPlayer=false},
                    new Player{Number=3, Name="Alexandr Shapovalov",Height=192,RoleId=roles.Single(i=>i.Name=="Passer").Id,TeamId=1,CountOfTheBestPlayer=2,Category="KMS", Birth=new DateTime(1991,5,8), IsCaptain=false, IsBestGroupPlayer=false},
                    new Player{Number=5, Name="Bogdan Polovinskiy",Height=190,RoleId=roles.Single(i=>i.Name=="Vtoroy Temp").Id,TeamId=teams.Single(i=>i.Name=="Meridian").Id,CountOfTheBestPlayer=5,Category="1 level", Birth=new DateTime(1989,2,8), IsCaptain=true, IsBestGroupPlayer=true},
                    new Player{Number=5, Name="Roman Romanenko",Height=189,RoleId=roles.Single(i=>i.Name=="Libero").Id,TeamId=teams.Single(i=>i.Name=="Boryspil").Id,CountOfTheBestPlayer=5,Category="1 level", Birth=new DateTime(1988,2,8), IsCaptain=true, IsBestGroupPlayer=false},
                    new Player{Number=5, Name="Vladislav Mushynskiy",Height=190,RoleId=roles.Single(i=>i.Name=="Libero").Id,TeamId=teams.Single(i=>i.Name=="Meridian").Id,CountOfTheBestPlayer=2,Category="1 level", Birth=new DateTime(1992,72,15), IsCaptain=false, IsBestGroupPlayer=false},
            };
            foreach (Player e in players)
            {
                context.Players.Add(e);
            }
            context.SaveChanges();
            #endregion
        }
    }
}