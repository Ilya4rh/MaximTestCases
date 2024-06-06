namespace MaximTestCases.RequestsLimitLogic.Interfaces;

public interface IRequestsLimitService
{
    Task<bool> IsLimit();

    void Exit();
}