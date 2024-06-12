using NBench;
using ThesisManagementSystem.Data;
using ThesisManagementSystem.Repositories;

namespace Tests
{
    internal class ThesisStresTests
    {
        Counter counter;
        StudentRepository studentRepository;
        DbContextClass _dbContext;
        int studentId;


        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            studentRepository = new(_dbContext);
            counter = context.GetCounter("CheckoutCounter");
            studentId = 1;
        }

        [PerfBenchmark(NumberOfIterations = 5,
            RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 2000,
            TestMode = TestMode.Test)]
        [CounterThroughputAssertion("CheckoutCounter", MustBe.GreaterThan, 50000)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated,MustBe.LessThanOrEqualTo,ByteConstants.SixtyFourKb)]
        public void Checkout_Test()
        {
            studentRepository.GetStudentListAsync();
            counter.Increment();
        }


        [PerfBenchmark(NumberOfIterations = 5,
          RunMode = RunMode.Throughput,
          RunTimeMilliseconds = 2000,
          TestMode = TestMode.Test)]
        [CounterThroughputAssertion("CheckoutCounter", MustBe.GreaterThan, 100000)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.EightKb)]
        public void Checkout_Test2()
        {
            studentRepository.GetYearOfStudies(studentId);
            counter.Increment();
        }




        [PerfCleanup]
        public void Cleanup()
        {

        }
    }
}
