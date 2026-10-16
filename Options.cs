using Menu.Remix.MixedUI;

namespace TestIterator;

public class Options : OptionInterface {
    public static Configurable<bool> infocardFlash;
    public static Configurable<bool> sillyMode;
    // Silly mode
    public static Configurable<bool> sisyphus;
    public static Configurable<bool> bombDetachment;
    public static Configurable<bool> rainbowLight;
    
    public Options() {
        infocardFlash = config.Bind("testiterator_infocardFlashOption", true,
            new ConfigurableInfo("Enables info card flashing for unknown objects"));
        sillyMode = config.Bind("testiterator_sillyModeOption", true);
        sisyphus = config.Bind("testiterator_sisyphusOption", true, new ConfigurableInfo("Saint only, 10% chance"));
        bombDetachment = config.Bind("testiterator_bombDetachmentOption", true, new ConfigurableInfo("Always available"));
        rainbowLight = config.Bind("testiterator_rainbowLightOption", true, new ConfigurableInfo("1% chance"));
    }

    public override void Initialize() {
        base.Initialize();
        OpTab genTab, sillyTab;
        Tabs = [
            genTab = new OpTab(this, "General"),
            sillyTab = new OpTab(this, "Silly mode")
        ];

        float offY = 0f;
        UIQueue.InitializeQueues(genTab, 0f, ref offY,
            new OpCheckBox.Queue(infocardFlash)
        );
        offY = 0f;
        UIQueue.InitializeQueues(sillyTab, 0f, ref offY,
            new OpLabel.Queue("Silly mode is a variety of joke or easter egg content, mostly in the form of iterator behavior."),
            new OpLabel.Queue("It alters or replaces stuff you would normally see, so enable this on your first experience at your own risk."),
            new OpLabel.Queue("You can configure each thing and see the chances of it triggering down below."),
            new OpLabel.Queue("Note that Inv's campaign always has silly mode enabled."),
            new OpLabel.Queue("Some things are also Inv-exclusive, and cannot be disabled."),
            new OpCheckBox.Queue(sillyMode),
            new OpLabel.Queue("Individual things", FLabelAlignment.Center, true),
            new OpCheckBox.Queue(sisyphus),
            new OpCheckBox.Queue(bombDetachment),
            new OpCheckBox.Queue(rainbowLight)
        );
    }
}