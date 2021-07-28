using System.Threading.Tasks;

namespace WrapperExample.TpsService
{
    public interface ITpsService
    {
        Patient Patient { get; }
        Plan Plan { get; }
    }
}


