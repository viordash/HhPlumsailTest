namespace HhPlumsailApp.Exceptions {
	public class DuplicateRecordException : PsException {
		public DuplicateRecordException() : base("The record is exists") {

		}
	}
}