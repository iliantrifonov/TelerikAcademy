namespace _03.FindSetOfWordsWithTrie
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Gma.DataStructures.StringSearch;
    using System.Diagnostics;

    public class Program
    {
        public static void Main(string[] args)
        {
            string text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce interdum, lectus quis auctor molestie, eros lorem venenatis arcu, sed malesuada ante elit sit amet nulla. Ut sodales ipsum diam, sit amet vulputate sem efficitur nec. Vestibulum malesuada, lorem nec faucibus euismod, justo arcu dapibus metus, eget dignissim dui ipsum at massa. Cras porta vulputate ullamcorper. Nullam tincidunt fringilla augue, sit amet tincidunt tellus molestie nec. Aenean luctus aliquet quam, sit amet efficitur purus blandit nec. Phasellus blandit vel sapien a pharetra.

Morbi iaculis vel justo quis euismod. Nullam id massa a ante tempus gravida interdum vel sem. Morbi maximus iaculis ex vel suscipit. Duis mollis dui eget lacus luctus, ac porta sem feugiat. Sed placerat, nisi non congue consectetur, quam nisl laoreet diam, non cursus arcu lacus lacinia sem. Donec volutpat orci ut sagittis fringilla. Interdum et malesuada fames ac ante ipsum primis in faucibus. Sed auctor enim ut nulla finibus hendrerit. Ut tristique nisi vel massa varius dignissim.

Nulla facilisi. Quisque pulvinar diam sed turpis porta, vel viverra ligula lobortis. In finibus molestie cursus. Mauris ut efficitur neque. Aenean consequat orci in metus varius, eget placerat quam cursus. Donec enim neque, mollis id maximus sed, viverra in turpis. Pellentesque tempus sed ante sed consectetur. Quisque suscipit libero sem, at efficitur metus mattis at. Praesent maximus lacus id odio consequat iaculis. Sed finibus tincidunt dolor, sed finibus felis viverra vel. Suspendisse a accumsan nibh. Sed leo augue, vehicula sit amet pulvinar a, tincidunt a lorem. Etiam consectetur consectetur urna, vel vestibulum augue posuere a. In a leo ornare justo vestibulum vestibulum. Proin vehicula elit a urna auctor, sed vestibulum nisl finibus.

Vestibulum tristique turpis sed felis lobortis egestas. Vivamus molestie metus ut auctor fermentum. Donec interdum feugiat mi quis mattis. Praesent faucibus fermentum erat non dapibus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aenean vitae orci id massa aliquet mattis. Nam luctus augue at dui finibus, non interdum leo tristique.

Etiam non magna non ex pellentesque ullamcorper. Donec sodales sem ut magna accumsan, eget euismod nibh congue. Cras eros mauris, gravida eu sapien eget, vehicula tristique elit. Suspendisse commodo arcu ut mi vestibulum, in volutpat elit fringilla. Vivamus gravida leo quis diam dignissim, sed efficitur ex rhoncus. Suspendisse finibus bibendum dolor, ut aliquet urna egestas sed. Sed in rutrum est, eget aliquet justo.

Suspendisse eleifend imperdiet sapien in posuere. Etiam ultrices eu metus in condimentum. Vivamus ac urna congue, commodo tortor sit amet, porta libero. Proin dolor libero, dignissim et leo ac, elementum faucibus lectus. Morbi semper turpis semper, mattis sapien et, luctus lacus. Curabitur sem purus, rutrum quis augue et, semper tristique nisl. Nam pretium molestie lacus, nec egestas orci pellentesque a. In vel erat quis tortor pulvinar viverra accumsan tristique orci. Nulla euismod cursus lacus, vel dapibus sem tincidunt id. Ut dictum euismod eleifend. Nulla tincidunt cursus urna eu lacinia. Etiam lacinia egestas blandit. Ut nisi justo, euismod a est at, rutrum sodales orci.

Etiam et mi tempus, varius ex sed, sollicitudin lacus. Nunc convallis blandit urna in laoreet. Ut mattis lorem at elementum dapibus. Nam faucibus rutrum sem, porta elementum leo luctus et. Integer ex urna, rhoncus ac odio vitae, pharetra lacinia leo. Cras vel arcu commodo, molestie ex id, sodales mauris. Ut vitae dui dignissim risus tempus sodales. Duis ac tellus commodo, efficitur arcu id, dapibus leo. Proin nec suscipit libero. In eros urna, tempus vitae vestibulum ut, fringilla ut nisl. Etiam eu ligula vel libero tristique finibus. Nulla et vestibulum nunc.

Phasellus eu nunc vitae turpis ornare vulputate. Integer viverra, neque ac consectetur egestas, diam lorem feugiat orci, id laoreet odio mi non tortor. Vivamus eu ligula accumsan, vestibulum libero nec, convallis tellus. Sed commodo, augue ut fermentum gravida, nibh eros suscipit felis, in hendrerit dolor erat nec ipsum. Sed eget ultricies mauris. Sed ac dui ligula. Nullam quis tempus neque. Sed tincidunt ante eget purus placerat posuere. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse luctus libero tortor, quis porta dolor mollis a. Cras sed orci lobortis, tincidunt libero quis, ultrices massa. In ac erat lorem. Etiam et porttitor tellus. Cras nulla nisi, posuere cursus justo in, elementum fringilla lacus. Aenean posuere nibh sed dolor semper tempor.

Etiam enim ex, iaculis ut bibendum eu, ultricies et lectus. Sed ut viverra enim, sed scelerisque lectus. Quisque semper id est nec sagittis. Pellentesque ac mi venenatis arcu scelerisque bibendum. Sed pellentesque convallis molestie. Nam tincidunt pellentesque lacus, id accumsan nulla pharetra id. Integer eu sapien pellentesque, imperdiet ligula eget, faucibus ipsum. Proin ornare elit a risus tempor ultrices. Praesent eu posuere lacus, nec dictum neque. Donec nulla lectus, accumsan sit amet diam a, dictum mollis justo. Mauris pharetra erat nisi, at malesuada ipsum dictum nec. Mauris orci nunc, eleifend vel pulvinar ac, viverra ut ipsum.

Nullam ac lectus viverra, vestibulum felis eu, bibendum nisl. Nullam sed ullamcorper ante. Quisque ac porttitor massa. Phasellus efficitur cursus erat, vel vestibulum nisl condimentum consectetur. Sed risus tellus, facilisis a interdum quis, tincidunt sit amet tortor. Donec vel vestibulum massa. Sed in consequat urna. Phasellus ullamcorper mollis odio, vitae sollicitudin mi pretium vitae. Quisque volutpat ipsum non diam placerat, non ornare turpis rhoncus. Proin interdum, felis et mollis dictum, lorem erat mattis quam, ac laoreet orci ante et eros. Donec tristique justo felis, eget rhoncus velit tempus in. Aliquam eu tellus faucibus, ornare nisi id, mollis libero. ";
            var sb = new StringBuilder(text);
            for (int i = 0; i < 1000; i++)
            {
                sb.Append(text);
            }


            var sw = new Stopwatch();
            sw.Start();
            var trie = new Trie<string>();
            var split = sb.ToString().Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in split)
            {
                trie.Add(word, word);
            }

            Console.WriteLine(sw.Elapsed);      
            var set = new HashSet<string>(split);
            foreach (var word in set)
            {
                Console.WriteLine(word + " " + trie.Retrieve(word).Count());
            }

            Console.WriteLine("With the time for building it, and printing on console.writeline : " + sw.Elapsed);
        }
    }
}
