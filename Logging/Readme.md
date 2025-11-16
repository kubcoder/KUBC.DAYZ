# KUBC.DAYZ.Logging
Журналы сервера, чтение, парсинг.

Данный программный модуль разрабатывался с целью чтения логов сервера «на лету», т.е. сервер пишет логи, а программа на ходу их читает и публикует данные происходящего в игре. Пример работы данного алгоритма можно увидеть тут: [kubanoids.ru](https://www.kubanoids.ru/sakhal/ingame/actions)
## Философия работы с логами
Основной инструмент для работы с файлом лога сервера представлен абстрактным классом `LogFile`. Который ориентирован на возможность чтения файла на лету, т.е. мы можем дочитывать файл если он обновился. Закрытие файла выполняется по вызову метода `Dispose()`. Класс прочитав строчку вызывает метод `OnLineReadAsync(string line)`, метод вызывается только в случае если мы дочитали до конца строки, если символ конца строки не найден то метод не вызывается.

Так как большинство логов сервера содержат сокращенное время события, для работы с логами используется абстрактный класс `LogFileShortTime`, который содержит инструменты для корректировки времени.

Для реализации чтения лога в приложении необходимо реализовать какой то из абстрактных классов лога, в котором реализовать обработку входящих строк в методе `OnLineRead(DateTime time, string data)`, в который передается время когда произошло событие на сервере и строка информации, для анализа которой можно использовать один из включенных в проект парсеров событий сервера.

# RPT
Журнал сервера реального времени, хотя, наверное, реальное время в прошлом, по факту он не всегда пишет постоянно. 

Абстрактный класс для чтения файла журнала `RealTimeLogFile` реализует чтение журнала, и анализирует дату и время создания журнала, и метод `OnLineRead(DateTime time, string data)` вызывается с передачей времени UTC журнала.

Реализованы события журнала:
- `AverageServerFPS` Средний ФПС сервера, парсер `AverageServerFPSBuilder`
- `UsedMemory` Размер памяти, используемый сервером, парсер `UsedMemoryBuilder`
- `PlayerSteamFound` Запись о Steam ID подключаемого игрока, парсер `PlayerSteamFoundBuilder`

# ADM
> Парсеры модуля разработаны на основе [документации от разработчиков](https://community.bistudio.com/wiki/DayZ:Administration_Logs)

Журнал лога администраторов сервера, содержит информацию о том, кто где ходил, что делал, и от чего умирал.

Абстрактный класс для чтения файла журнала `AdminLogFile` реализует чтение журнала, и анализирует дату и время создания журнала, и метод `OnLineRead(DateTime time, string data)` вызывается с передачей времени UTC журнала.

Реализованы события журнала:
- `AveragePlayerCount` Количество игроков на сервере, парсер `AveragePlayerCountBuilder`
- `BledOut` Игрок истек кровью, парсер `BledOutBuilder`
- `Built` Событие строительства игроком, парсер `BuiltBuilder`
- `Chat` Событие игрового чата, парсер `ChatBuilder`
- `Dismantled` Событие когда игрок разобрал базу, парсер `DismantledBuilder`
- `DugIn` Событие закапывания объекта, парсер `DugInBuilder`
- `DugOut` Событие выкапывания объекта, парсер `DugOutBuilder`
- `Emote` Событие когда игрок сотворил какую то эмоцию, или там сел или еще какую анимацию замутил, парсер `EmoteBuilder`
- `EmoteWithItem` Эмоция игрока, с предметом в руках, парсер `EmoteBuilder`
- `Folded`  Событие складывания объекта, парсер `FoldedBuilder`
- `KilledByDistanceWeapon` Игрок убит другим игроком с дальнобойного оружия, парсер `KilledByDistanceWeaponBuilder`
- `KilledByHands` Игрок забил другого игрока руками до смерти, парсер `KilledByHandsBuilder`
- `KilledByItem` Игрок убит каким то игровым предметомИгрок убит каким то игровым предметом, парсер `KilledByItemBuilder`
- `KilledByWeapon` Игрока убил другой игрок с помощью оружия, парсер `KilledByWeaponBuilder`
- `KilledByZombie` Игрок убит зомби, парсер `KilledByZombieBuilder`
- `Lowered` Событие опускания тотема, парсер `LoweredBuilder`
- `Mounted` Событие монтажа элемента, парсер `MountedBuilder`
- `Packed` Событие упаковки (обычно используется с палатками), парсер `PackedBuilder`
- `Placed` Событие размещения объекта, парсер `PlacedBuilder`
- `PlayerChoosingRespawn` Событие игрок нажал кнопочку РЕСПАВН в состоянии когда персонаж бессознания, парсер `PlayerChoosingRespawnBuilder`
- `PlayerConnected` Событие подключения игрока, парсер `PlayerConnectedBuilder`
- `PlayerDied` Событие игрок умер, парсер `PlayerDiedBuilder`
- `PlayerDisconnectedDied`Событие игрок отключился, парсер `PlayerDisconnectedBuilder`
- `PlayerFall` Событие когда игрок получил урон падая с высоты, парсер `PlayerFallBuilder`
- `PlayerHitByDistanceWeapon` Урон нанесен с помощью дальнобойного оружия, парсер `PlayerHitByDistanceWeaponBuilder`
- `PlayerHitByExplosion` Урон игроку от бризантного боеприпаса, парсер `PlayerHitByExplosionBuilder`
- `PlayerHitByItem` Игрок получил урон от предмета или игровой механики, парсер `PlayerHitByItemBuilder`
- `PlayerHitByItemInZone` Урон игроку от некого игрового итема с указанием зоны поражения, парсер `PlayerHitByItemInZoneBuilder`
- `PlayerHitByPlayer` Событие игрок получил урон от другого игрока без использования оружия. Буквально выражаясь кулаками побил, парсер `PlayerHitByPlayerBuilder`
- `PlayerHitByTransport` Урон игроку в ДТП, парсер `PlayerHitByTransportBuilder`
- `PlayerHitByWeapon` Урон игроку от другого игрока с использованием оружия. Прямым использованием т.е. топоры, молоты и прочее, но уже не голыми руками, парсер `PlayerHitByWeaponBuilder`
- `PlayerHitByZmb` Урон игроку нанесен зомбем, парсер `PlayerHitByZmbBuilder`
- `Raised` Событие подъема тотема, парсер `RaisedBuilder`
- `Report` Базовое событие жалобы/отчета игрока, парсер `ReportBuilder`
- `Suicide` Игрок все таки совершил суицид, парсер `SuicideBuilder`
- `Unconscious` Событие игрок потерял сознание, парсер `UnconsciousBuilder`
- `UnconsciousDisconect` Событие когда игрок отключился в бессознательном состоянии, парсер `UnconsciousDisconectBuilder`
- `Unmounted` Событие демонтажа элемента с конструкции, парсер `UnmountedBuilder`

