namespace Composite
{
    public abstract class FileSystemItem
    {
        public string Name { get; set; }
        public abstract long GetSize();

        public FileSystemItem(string name)
        {
            Name = name;
        }
    }

    public class File : FileSystemItem
    {
        private long _size;
        public File(string name, long size) : base(name)
        {
            _size = size;
        }

        public override long GetSize()
        {
            return _size;
        }
    }

    public class Directory : FileSystemItem
    {
        private List<FileSystemItem> _fileSystemItems = new List<FileSystemItem>();
        private long _size;
        public Directory(string name, long size) : base(name)
        {
            _size = size;
        }

        public void Add(FileSystemItem itemToAdd)
        {
            _fileSystemItems.Add(itemToAdd);
        }

        public void Remove(FileSystemItem itemToRemove)
        {
            _fileSystemItems.Remove(itemToRemove);
        }

        public override long GetSize()
        {
            var treeSize = _size;
            foreach (var item in _fileSystemItems)
            {
                treeSize += item.GetSize();
            }
            return treeSize;
        }
    }
}