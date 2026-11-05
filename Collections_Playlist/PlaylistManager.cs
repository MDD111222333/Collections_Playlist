using System;
using System.Collections.Generic;

namespace Collections_Playlist
{
    public class PlaylistManager
    {
        private LinkedList<string> playlist = new LinkedList<string>();
        private LinkedListNode<string>? currentNode;

        public void AddSong(string song)
        {
            var newNode = playlist.AddLast(song);
            if (currentNode == null)
            {
                currentNode = newNode;
            }
        }

        public void PlayNext(string song)
        {
            if (currentNode != null)
            {
                currentNode = playlist.AddAfter(currentNode, song);
            }
            else
            {
                AddSong(song);
            }
        }

        public LinkedListNode<string>? FindSong(string song)
        {
            return playlist.Find(song);
        }

        public void RemoveSong(string song)
        {
            var node = FindSong(song);
            if (node != null)
            {
                if (node == currentNode)
                {
                    currentNode = node.Next ?? node.Previous;
                }
                playlist.Remove(node);
            }
        }

        public void PrintPlaylist()
        {
            Console.WriteLine("Текущий плейлист: " + string.Join(", ", playlist));
            if (currentNode != null)
            {
                Console.WriteLine($"Сейчас играет: {currentNode.Value}");
            }
            else
            {
                Console.WriteLine("Плейлист пуст.");
            }
        }
    }
}