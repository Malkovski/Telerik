var Infestation = (function () {
    var createdUnits = [],
        UNIT_KINDS = ['Dog', 'Tank', 'Marine', 'Parasite', 'Queen'],
        SUPPLEMENT_TYPES = ['PowerCatalyst', 'HealthCatalyst', 'AggressionCatalyst', 'Weapon', 'InfestationSpores'];

    function isCreatedTarget(targetName) {
        return createdUnits.some(function (target) {
            return  target._name === targetName;
        });
    }

    function isValidUnitKind(unitKind) {
        return UNIT_KINDS.some(function (kind) {
            return kind === unitKind;
        });
    }

    function isValidSupplementType(supplementType) {
        return SUPPLEMENT_TYPES.some(function (type) {
            return type === supplementType;
        });
    }

    function validateUnitName(name) {
        if (!name.match(/^[0-9A-z_]+$/)) {
            throw new Error('Unit name must be alpha-numeric!');
        }//
    }

    function getSupplementEffect(unit, currentSupplement) {
        if (currentSupplement.id === 'Weapon' && !hasWeaponrySkill(unit)) {
            unit._baseHealth += 0;
            unit._basePower += 0;
            unit._baseAggro += 0;
        }
        else {
            unit._baseHealth += currentSupplement._healthBonus;
            unit._basePower += currentSupplement._powerBonus;
            unit._baseAggro += currentSupplement._aggroBonus;
        }
    }

    function hasWeaponrySkill(unit) {
        return unit._supplements.some(function (supplement) {
            return  supplement.id === 'WeaponrySkill';
        });
    }

    function calculateDamageDealt(attacker, victim) {
        victim._baseHealth -= attacker._basePower;
    }

    function calculateInfestation(attacker, victim) {
        if (attacker._type === 'Psionic') {
            tryToInfest(victim);
        }
        else {
            if (victim._type === 'Biological') {
                tryToInfest(victim);
            }
        }
    }

    function tryToInfest(victim) {
        if (!checkForInfestationSpore(victim)) {
            var currentInfestation = new InfestationSpores.init();
            victim._supplements.push(currentInfestation);
            getSupplementEffect(victim, currentInfestation);
        }
    }

    function checkForInfestationSpore(victim) {
        return victim._supplements.some(function (supplement) {
            return supplement.id === 'InfestationSpores';
        })
    }

    var HoldingPen = (function () {
        
        var holdingPen = {

            insert: function (unitKind, unitName) {
                var currentUnit;

                if (!isValidUnitKind(unitKind)) {
                    throw new Error('No such kind of unit!');
                }

                switch (unitKind) {
                    case 'Dog': currentUnit = Object.create(Dog).init(unitName);
                        break;
                    case 'Tank': currentUnit = Object.create(Tank).init(unitName);
                        break;
                    case 'Marine': currentUnit = Object.create(Marine).init(unitName);
                        break;
                    case 'Parasite': currentUnit = Object.create(Parasite).init(unitName);
                        break;
                    case 'Queen': currentUnit = Object.create(Queen).init(unitName);
                        break;

                    default : break;
                }

                createdUnits.push(currentUnit);
            },
            supplement: function (supplementType, targetUnitName) {
                var currentSupplement;

                if (!isValidSupplementType(supplementType)) {
                    throw new Error('This kind of supplement do not exists!');
                }

                if (!isCreatedTarget(targetUnitName)) {
                    throw  new Error('No such unit!');
                }

                switch (supplementType) {
                    case 'PowerCatalyst' : currentSupplement = Object.create(PowerCatalyst).init();
                        break;
                    case 'HealthCatalyst' : currentSupplement = Object.create(HealthCatalyst).init();
                        break;
                    case 'AggressionCatalyst' : currentSupplement = Object.create(AggressionCatalyst).init();
                        break;
                    case 'Weapon' : currentSupplement = new Weapon.init();
                        break;

                    default : break;
                }

                createdUnits.forEach(function (unit) {
                    if (unit._name === targetUnitName) {
                        unit._supplements.push(currentSupplement);
                        getSupplementEffect(unit, currentSupplement);
                    }
                });
            },
            proceed: function () {
                createdUnits.forEach(function (unit) {
                    var currentAction = unit.interact(unit, createdUnits),
                        attackType = currentAction[1],
                        victim = currentAction[0];

                    if (victim !== undefined) {
                        console.log(unit._name + ' ' + attackType + 's  ' + victim._name);
                        switch (attackType) {
                            case 'attack': calculateDamageDealt(unit, victim);
                                break;
                            case 'infest': calculateInfestation(unit, victim);
                                break;

                            default : break;
                        }
                    }
                });
            },
            status: function () {
                createdUnits.forEach(function (unit) {
                    var report = unit.id + ' ' + unit._name + ': ' + 'health:' + unit._baseHealth + ' power:' +
                        unit._basePower + ' aggression:' + unit._baseAggro + ' Supplements added:' +
                        unit._supplements.length;

                    if (unit._supplements.length > 0) {
                        var supplementNames = '';

                        unit._supplements.forEach(function (supplement) {
                            supplementNames += supplement.id + ', ';
                        });

                        supplementNames = supplementNames.trim().slice(0, supplementNames.length - 2);

                        report += ' - [' + supplementNames + ']';
                    }

                    console.log(report);
                });
            }
        };

        return holdingPen;
    })();

    var Unit = (function () {
        var unit = {
            init: function (name, type, baseHealth, basePower, baseAggro) {
                validateUnitName(name);

                this._name = name;
                this._type = type;
                this._baseHealth = baseHealth || 5;
                this._basePower = basePower || 1;
                this._baseAggro = baseAggro || 1;
                this._supplements = [];

                return this;
            }
        };

        return unit;
    })();
    
    var Dog = (function (parent) {
        var dog = {
            init: function (name) {
                parent.init.call(this, name, 'Biological', 1, 1, 2);
                this.id = 'Dog';

                return this;
            },
            interact: function(unit, enemies) {
                var possibleEnemies = enemies.filter(function(enemy) {
                    return enemy._name !== unit._name;
                }).sort(function (a, b) {
                    return b._baseAggro - a._baseAggro;
                });

                return [possibleEnemies[0], 'attack'];
            }
        };

        return dog;
    })(Unit);

    var Tank = (function (parent) {
        var tank = {
            init: function (name) {
                parent.init.call(this, name, 'Mechanical', 20, 25, 25);
                this.id = 'Tank';

                return this;
            },
            interact: function(unit, enemies) {
                var possibleEnemies = enemies.filter(function(enemy) {
                    return enemy._name !== unit._name;
                }).sort(function (a, b) {
                    return b._baseAggro - a._baseAggro;
                }).sort(function (a, b) {
                    return b._baseHealth - a._baseHealth;
                });

                return [possibleEnemies[0], 'attack'];
            }
        };

        return tank;
    })(Unit);

    var Marine = (function (parent) {
        var marine = {
            init: function (name) {
                parent.init.call(this, name, 'Human');
                this.id = 'Marine';
                this._supplements = [new WeaponrySkill.init()];

                return this;
            },
            interact: function(unit, enemies) {
                var possibleEnemies = enemies.filter(function(enemy) {
                    return enemy._name !== unit._name;
                }).filter(function (enemy) {
                    return  enemy._basePower <= unit._baseAggro;
                }).sort(function (a, b) {
                    return a._baseHealth - b._baseHealth;
                });

                return [possibleEnemies[0], 'attack'];
            }
        };

        return marine;
    })(Unit);

    var Parasite = (function (parent) {
        var parasite = {
            init: function (name) {
                parent.init.call(this, name, 'Biological', 1, 1, 1);
                this.id = 'Parasite';

                return this;
            },
            interact: function(unit, enemies) {
                var possibleEnemies = enemies.filter(function(enemy) {
                    return enemy._name !== unit._name;
                }).sort(function (a, b) {
                    return a._baseHealth - b._baseHealth;
                });

                return [possibleEnemies[0], 'infest'];
            }
        };

        return parasite;
    })(Unit);

    var Queen = (function (parent) {
        var queen = {
            init: function (name) {
                parent.init.call(this, name, 'Psionic', 30, 1, 1);
                this.id = 'Queen';

                return this;
            },
            interact: function(unit, enemies) {
                var possibleEnemies = enemies.filter(function(enemy) {
                    return enemy._name !== unit._name;
                }).sort(function (a, b) {
                    return a._baseHealth - b._baseHealth;
                });

                return [possibleEnemies[0], 'infest'];
            }
        };

        return queen;
    })(Unit);

    var Supplement = (function () {

        var supplement = {
            init: function (healthBonus, powerBonus, aggroBonus) {
                this._healthBonus = healthBonus || 0;
                this._powerBonus = powerBonus || 0;
                this._aggroBonus = aggroBonus || 0;

                return this;
            }
        };

        return supplement;
    })();

    var PowerCatalyst = (function (parent) {
        var powerCatalyst = {
            init: function () {
                parent.init.call(this, 0, 3, 0);
                this.id = 'PowerCatalyst';

                return this;
            }
        };

        return powerCatalyst;
    })(Supplement);

    var HealthCatalyst = (function (parent) {
        var healthCatalyst = {
            init: function () {
                parent.init.call(this, 3, 0, 0);
                this.id = 'HealthCatalyst';

                return this;
            }
        };

        return healthCatalyst;
    })(Supplement);

    var AggressionCatalyst  = (function (parent) {
        var aggressionCatalyst  = {
            init: function () {
                parent.init.call(this, 0, 0, 3);
                this.id = 'AggressionCatalyst';

                return this;
            }
        };

        return aggressionCatalyst ;
    })(Supplement);

    var WeaponrySkill  = (function (parent) {
        var weaponrySkill  = {
            init: function () {
                parent.init.call(this);
                this.id = 'WeaponrySkill';

                return this;
            }
        };

        return weaponrySkill ;
    })(Supplement);

    var Weapon  = (function (parent) {
        var weapon  = {
            init: function () {
                parent.init.call(this, 0, 10, 3);
                this.id = 'Weapon';

                return this;
            }
        };

        return weapon ;
    })(Supplement);

    var InfestationSpores   = (function (parent) {
        var infestationSpores   = {
            init: function () {
                parent.init.call(this, -1, 0, 20);
                this.id = 'InfestationSpores';

                return this;
            }
        };

        return infestationSpores;
    })(Supplement);

    HoldingPen.insert('Marine', 'Gosho');
   // HoldingPen.insert('Dog', 'maro');
   // HoldingPen.insert('Tank', 'T72');
   // HoldingPen.insert('Parasite', 'ebola');
    HoldingPen.insert('Queen', 'Ant');
   // HoldingPen.supplement('Weapon', 'Gosho');
   // HoldingPen.supplement('PowerCatalyst', 'Gosho');
   // HoldingPen.supplement('HealthCatalyst', 'Gosho');
   // HoldingPen.supplement('AggressionCatalyst', 'Gosho');
   // HoldingPen.supplement('Weapon', 'Gosho');
   // HoldingPen.supplement('Weapon', 'T72');
    HoldingPen.proceed();
    HoldingPen.status();

})();



