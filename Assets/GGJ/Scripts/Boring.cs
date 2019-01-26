using UniRx;

public class Boring
{
    readonly ReactiveProperty<float> value = new ReactiveProperty<float>(0.5f);

    public IReadOnlyReactiveProperty<float> Value => value;
    
    public void SetValue(float v) => value.Value = v;
}