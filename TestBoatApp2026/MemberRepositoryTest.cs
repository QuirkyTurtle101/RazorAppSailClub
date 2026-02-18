using SailClubLibrary.Exceptions;
using SailClubLibrary.Models;
using SailClubLibrary.Services;

namespace TestBoatApp2026
{
    [TestClass]
    public sealed class MemberRepositoryTest
    {
        [TestMethod]
        public void AddMemberTest()
        {
            MemberRepository testRepo = new MemberRepository();

            int beforeCount = testRepo.Count;
            testRepo.AddMember(new Member(1, "John", "Testman", "12345678", "Test Lane 123", "Unitville", "unit@test.net", MemberType.Adult, MemberRole.Member));
            int afterCount = testRepo.Count;

            Assert.AreEqual(beforeCount+1, afterCount);
        }

        [TestMethod]
        public void UpdateMemberTest()
        {
            MemberRepository testRepo = new MemberRepository();
            testRepo.AddMember(new Member(1, "John", "Testman", "12345678", "Test Lane 123", "Unitville", "unit@test.net", MemberType.Adult, MemberRole.Member));

            Member update = new Member(1, "Dave", "Testman", "12345678", "Test Lane 123", "Unitville", "unit@test.net", MemberType.Adult, MemberRole.Member);
            testRepo.UpdateMember(update);

            Assert.AreEqual("Dave", testRepo.SearchMember("12345678").FirstName);
        }

        [TestMethod]
        [ExpectedException(typeof(MemberPhoneNumberExistsException))]
        public void AddExistingMemberTest()
        {
            MemberRepository testRepo = new MemberRepository();
            testRepo.AddMember(new Member(1, "John", "Testman", "12345678", "Test Lane 123", "Unitville", "unit@test.net", MemberType.Adult, MemberRole.Member));

            testRepo.AddMember(new Member(1, "John", "Testman", "12345678", "Test Lane 123", "Unitville", "unit@test.net", MemberType.Adult, MemberRole.Member));

            //no assertion - this should throw an exception
        }
    }
}
