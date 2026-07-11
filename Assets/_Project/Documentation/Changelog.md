Version: 0.1.0

Added:

Production folder structure Scene structure Application constants Version constants

No gameplay implemented yet.

Version:

```
\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\`0.2.0\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\`
```

Added:

- Bootstrap architecture

- Persistent GameRoot

- Scene startup flow

- Foundation for service layer

### Version

```
\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\`0.3.0\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\`
```

### Added

- SaveData model

- SaveService

- JSON serialization

- PlayerPrefs persistence

- Centralized save architecture

### Version

```
\\\\\\\\\\\\\\\`0.4.0\\\\\\\\\\\\\\\`
```

### Added

- AudioService

- Music playback

- SFX playback

- Music mute support

- SFX mute support

- GameRoot audio integration

## Added

### ThemeData

Responsible for:

```
\\\\\\\`Theme ID\\\\\\\`      
      
\\\\\\\`Theme Name\\\\\\\`      
      
\\\\\\\`Board Colors\\\\\\\`      
      
\\\\\\\`Cell Colors\\\\\\\`      
      
\\\\\\\`Block Colors\\\\\\\`
```

### ThemeService

Responsible for:

```
\\\\\\\`Load Theme\\\\\\\`      
      
\\\\\\\`Save Theme\\\\\\\`      
      
\\\\\\\`Current Theme\\\\\\\`      
      
\\\\\\\`Theme Switching\\\\\\\`
```

### Save System Integration

Now stores:

```
\\\\\\\`SelectedThemeId\\\\\\\`
```

Added:

```
\\\`SettingsService\\\`    
    
\\\`Music Setting\\\`    
    
\\\`SFX Setting\\\`    
    
\\\`Haptics Setting\\\`    
    
\\\`Persistent Settings Support\\\`
```

Added:

- Actual block placement

- Board occupancy updates

- Placement persistence

- Occupied cell visualization

- Placement validation integration

Verified:

- Single block placement

- Multi-cell shape placement

- Occupied cell rejection

- Boundary rejection

Added:

- Block usage notifications

- Active block tracking

- Automatic tray regeneration

- Infinite gameplay loop


Verified:

- Tray refill after third placement

- Continuous gameplay cycles

- Stable runtime behavior
