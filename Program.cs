using System;
using System.Collections.Generic;

namespace TESTRUN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Log in to Spotifudge.");
            string username = GetUsername();
            string password = GetPassword();

            Console.WriteLine("Welcome " + username);
            Console.WriteLine();

            DisplayPlaylistInfo(username);

            List<string> discoverWeekly = GetDiscoverWeeklyPlaylist();

            int trackIndex = SelectTrack(discoverWeekly);

            if (trackIndex != -1)
            {
                string selectedTrack = discoverWeekly[trackIndex];
                Console.WriteLine("Now Playing: " + selectedTrack);
                Console.WriteLine();
            }

            bool exit = false;

            while (!exit)
            {
                int option = ShowOptions();

                switch (option)
                {
                    case 1:
                        bool isPaused = PauseOrPlayTrack();
                        if (isPaused)
                        {
                            PauseTrack();
                        }
                        else
                        {
                            PlayTrack(discoverWeekly[trackIndex]);
                        }
                        break;
                    case 2:
                        PlayRandomTrack(discoverWeekly);
                        break;
                    case 3:
                        SetRepeatOption();
                        break;
                    case 4:
                        AddToPlaylist();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static string GetUsername()
        {
            Console.Write("Username: ");
            return Console.ReadLine();
        }

        private static string GetPassword()
        {
            Console.Write("Password: ");
            return ReadPassword();
        }

        private static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (keyInfo.Key != ConsoleKey.Enter);

            return password;
        }

        private static void DisplayPlaylistInfo(string username)
        {
            Console.WriteLine("Discover Weekly");
            Console.WriteLine("Your weekly mixtape of fresh music. Enjoy new discoveries and deep cuts");
            Console.WriteLine("chosen just for you. Updated every Monday, so save your favorites!");
            Console.WriteLine("Made for " + username);
            Console.WriteLine("By Spotifudge");
            Console.WriteLine();
        }

        private static List<string> GetDiscoverWeeklyPlaylist()
        {
            return new List<string>() {
                "COOL (Your Rainbow) - NMIXX", "Wish I Could Be Your Girl - Kristiane",
                "That's Hilarious - Charlie Puth", "She's In The Rain - The Rose", "apollo - Faith Zapata",
                "Deja Vu - Uki Violeta, PrettyPatterns", "Good enough - Xdinary Heroes", "Make Me Happy - Whee In",
                "Huwag Muna Tayong Umuwi - BINI", "I Don't Wanna Be Alone - Ammon and Liahona Olayan",
                "Jazz Bar - Dreamcatcher", "Missed call (feat. Chancellor) - Jiselle, Chancellor",
                "TAKE MY HAND - Dream Maker", "Don't miss me - Claire Rosinkranz", "Back to the City - Kep1er",
                "cherry red - HNATA, Lydia Ganada", "ikaw at sila - Moira Dela Torre",
                "Love, Maybe (Acoustic Ver.) - KIMSEJEONG", "Manic Pixie Dream Girl - EASHA",
                "ZOOM - Juliet Ivy, Jeffrey Eli", "Over Me - BOYS PLANET", "Sofia - Clairo",
                "By My Side ft. Tiara Andini - Zack Tabudlo, Tiara Andini",
                "Bad Boy, Sad Girl - SEULGI, BE'O", "we fell in love in october - girl in red"
            };
        }

        private static int SelectTrack(List<string> discoverWeekly)
        {
            while (true)
            {
                for (int i = 0; i < discoverWeekly.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + discoverWeekly[i]);
                }

                Console.WriteLine();
                Console.Write("Select a track > ");
                int trackIndex = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (trackIndex >= 1 && trackIndex <= discoverWeekly.Count)
                {
                    return trackIndex - 1;
                }
                else
                {
                    Console.WriteLine("Invalid track selection. Please try again.");
                    Console.WriteLine();
                }
            }
        }

        private static int ShowOptions()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1. Pause/Play");
            Console.WriteLine("2. Shuffle");
            Console.WriteLine("3. Repeat");
            Console.WriteLine("4. Add to playlist");
            Console.WriteLine("5. Exit");
            Console.WriteLine();

            Console.Write("Enter your choice: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        private static bool isTrackPaused = false;

        private static bool PauseOrPlayTrack()
        {
            isTrackPaused = !isTrackPaused;
            return isTrackPaused;
        }

        private static void PlayTrack(string trackName)
        {
            Console.WriteLine();
            Console.WriteLine("Track played: " + trackName);
        }

        private static void PauseTrack()
        {
            Console.WriteLine();
            Console.WriteLine("Track paused.");
        }

        private static void PlayRandomTrack(List<string> discoverWeekly)
        {
            Console.WriteLine();
            Console.WriteLine("Shuffling tracks...");
            int randomTrackIndex = new Random().Next(0, discoverWeekly.Count);
            string randomTrack = discoverWeekly[randomTrackIndex];
            Console.WriteLine("Now Playing: " + randomTrack);
        }

        private static void SetRepeatOption()
        {
            bool isRepeated = false;
            int repeatOption;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Repeat the current song");
                Console.WriteLine("2. Repeat the whole playlist");
                Console.WriteLine("3. Disable repeat");
                Console.WriteLine("");

                Console.Write("Enter your choice: ");
                repeatOption = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (repeatOption)
                {
                    case 1:
                        Console.WriteLine("Repeating the current song.");
                        Console.WriteLine("");
                        isRepeated = true;
                        break;
                    case 2:
                        Console.WriteLine("Repeating the whole playlist.");
                        isRepeated = true;
                        break;
                    case 3:
                        if (!isRepeated)
                        {
                            Console.WriteLine("The track is not currently set to any repeat option.");
                        }
                        else
                        {
                            Console.WriteLine("Repeat disabled.");
                            isRepeated = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid repeat option.");
                        break;
                }
            } while (repeatOption != 3 || (repeatOption == 3 && isRepeated));
        }

        private static void AddToPlaylist()
        {
            Console.WriteLine();
            Console.WriteLine("Select Playlist:");
            Console.WriteLine("1. My Playlist 1");
            Console.WriteLine("2. My Playlist 2");
            Console.WriteLine("3. My Playlist 3");
            Console.WriteLine();

            Console.Write("Enter your choice: ");
            int playlistOption = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (playlistOption)
            {
                case 1:
                    Console.WriteLine("Added to My Playlist 1.");
                    break;
                case 2:
                    Console.WriteLine("Added to My Playlist 2.");
                    break;
                case 3:
                    Console.WriteLine("Added to My Playlist 3.");
                    break;
                default:
                    Console.WriteLine("Invalid playlist option.");
                    break;
            }
        }
    }
}
