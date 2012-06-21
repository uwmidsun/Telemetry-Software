using System;

namespace Telemetry
{
public class CANMessage
{
    private uint m_id = 0;
    private int m_length = 0;
    private float[] m_arr;

    //Dual 32-bit integer message
    public CANMessage(uint id, float high, float low)
    {
        m_id = id;
        m_arr = new float[2];
        m_arr[0] = high;
        m_arr[1] = low;
        m_length = 2;
    }

    //Quad 16-bit integer message
    public CANMessage(uint id, float val1, float val2, float val3, float val4)
    {
        m_id = id;
        m_arr = new float[4];
        m_arr[0] = val1;
        m_arr[1] = val2;
        m_arr[2] = val3;
        m_arr[3] = val4;
        m_length = 4;
    }

    // getters 
    public uint getId()
    {
        return m_id;
    }

    public float[] getArr()
    {
        return m_arr;
    }

    public int getLength()
    {
        return m_length;
    }
}
}