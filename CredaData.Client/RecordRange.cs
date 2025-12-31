namespace CredaData.Client
{

    public class RecordRange
    {
        private readonly int startRecord;

        private readonly int endRecord;

        public int EndRecord => endRecord;

        protected int StartRecord => startRecord;

        public RecordRange(int pageSize, int pageNumber, int totalResults)
        {
            startRecord = (pageNumber - 1) * pageSize + 1;
            endRecord = ((pageNumber * pageSize > totalResults) ? totalResults : (pageNumber * pageSize));
        }

        public override string ToString()
        {
            return $"{startRecord} to {endRecord}";
        }

        public string ToString(string formatter)
        {
            return string.Format(formatter, startRecord, endRecord);
        }
    }
}
